using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MathInUnity : MonoBehaviour
{

    public Transform a;
    public Transform b;
    public Vector2 Anorm;

    private void OnDrawGizmos()
    {
        Vector2 aPos = a.position;
        Vector2 bPos = b.position;

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(default, aPos);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, bPos);


        float aMag = Mathf.Sqrt(aPos.x * aPos.x + aPos.y * aPos.y);
        Vector2 aNorm = aPos / aMag;
        Vector2 aNormInbuilt = aPos.normalized;
        Gizmos.DrawSphere(aNormInbuilt, 0.1f);
        Anorm = aNormInbuilt;

        aPos = aPos.normalized;
    }
}
