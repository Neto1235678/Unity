using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public BoxCollider hurtBox;
    public Color colisionOpenColor;
    public Color collidingColor;
    public bool drawGizom = true;

    ColliderState state = ColliderState.Open;

    private void OnDrawGizmos()
    {
        if (!drawGizom)
            return;
        CheckGizomColor();
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawCube(hurtBox.center, hurtBox.size);
    }

    private void CheckGizomColor()
    {

        switch (state)
        {

            case ColliderState.Open:
                Gizmos.color = colisionOpenColor;
                break;
            case ColliderState.Colliding:
                Gizmos.color = collidingColor;
                break;
        }
    }

    public void GetHitBy(int damage)
    {
        state = ColliderState.Colliding;
        Invoke("ResetState", 0.2f);
    }

    void ResetState()
    {
        state = ColliderState.Open;
    }
}
