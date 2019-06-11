using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode] // EditMode에서 사용해달라.

public class GradientRawImage : MonoBehaviour
{

    public RawImage rawImage;
    public Color color1;
    public Color color2;

    [SerializeField]
    Texture2D backgroundTexture;

    private void Awake()
    {
        backgroundTexture = new Texture2D(1, 2);
        backgroundTexture.wrapMode = TextureWrapMode.Clamp;
        backgroundTexture.filterMode = FilterMode.Bilinear;
        SetColor(color1, color2);

    }

    private void SetColor(Color color1, Color color2)
    {
        backgroundTexture.SetPixels(new Color[] { color2, color1 });
        backgroundTexture.Apply();
        rawImage.texture = backgroundTexture;
    }

    private void OnValidate()
    {
        SetColor(color1, color2);
    }
}
