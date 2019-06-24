using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChattingMacro : MonoBehaviour
{
    public Color leftcolor;
    public Color rigthcolor;

    bool isAilgnLeft;
    public bool IsAlignLeft
    {
        get
        {
            return isAilgnLeft;
        }
        set
        {
            isAilgnLeft = value;
            Transform bubble = transform.GetChild(0);

            if (isAilgnLeft)
            {
                bubble.localRotation = Quaternion.AngleAxis(0, Vector3.up);
                bubble.GetComponent<Image>().color = rigthcolor;
                bubble.GetChild(0).localRotation = Quaternion.AngleAxis(0, Vector3.up);
                var h = GetComponent<HorizontalLayoutGroup>();
                h.childAlignment = TextAnchor.MiddleLeft;
                h.padding = new RectOffset(0, 200, 0, 0);
            }
            else
            {
                bubble.localRotation = Quaternion.AngleAxis(180, Vector3.up);
                bubble.GetComponent<Image>().color = leftcolor;
                bubble.GetChild(0).localRotation = Quaternion.AngleAxis(180, Vector3.up);
                var h = GetComponent<HorizontalLayoutGroup>();
                h.childAlignment = TextAnchor.MiddleRight;
                h.padding = new RectOffset(200, 0, 0, 0);
            }
        }
    }

    public void SetMessage(string message, bool isAlignLeft)
    {
        IsAlignLeft = isAilgnLeft;
        GetComponentInChildren<Text>().text = message;
    }
}
