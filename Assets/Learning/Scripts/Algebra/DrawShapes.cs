using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawShapes : MonoBehaviour
{


    public int height = 2;
    public float stairLength = 1;


    public float radiusOfCircle = 1f;
    [Range(1,25)]    public int angleInc = 1;
    private void OnDrawGizmos()
    {
        //DrawStair();


        DrawCircle();

    }

    private void DrawCircle()
    {
        for (int i = 0; i < 360; i += angleInc)
        {

            float angle = i * Mathf.Deg2Rad;
            Vector2 circlePos = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radiusOfCircle;

            Gizmos.color = Color.Lerp(Color.red, Color.green, i * 1f / 360);

            Gizmos.DrawSphere(circlePos, 0.3f);
        }
    }

    private void DrawStair()
    {
        Vector2 startPos;
        Vector2 endPos = Vector2.zero;

        for (int i = 0; i < height; i++)
        {

            float x = i % 2;
            float y = 1 - x;
            startPos = endPos;

            endPos += new Vector2(x, y) * stairLength;
            Gizmos.color = Color.Lerp(Color.red, Color.green, i * 1f / height);

            Gizmos.DrawLine(startPos, endPos);

        }
    }
}
