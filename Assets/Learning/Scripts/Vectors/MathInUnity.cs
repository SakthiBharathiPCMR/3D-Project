using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MathInUnity : MonoBehaviour
{

    public Transform a;
    public Transform b;
    public Vector2 aNorm;

    public float sclProj;

    public float radius;

    public int maxReflect;

    public LayerMask surLayer;
    public float angle;
    public Vector3 localPos;
    public Vector3 worldPos;

    private void OnDrawGizmos()
    {
        localPos = WorldToLocal(worldPos);
        Gizmos.DrawSphere(worldPos, 0.1f);
    }

    

    private Vector3 WorldToLocal(Vector3 worldCoord)
    {
        Vector3 rel = worldCoord - transform.position;
        float x = Vector3.Dot(rel,transform.right);
        float y = Vector3.Dot(rel, transform.up);
        return new Vector3(x,y);

    }

    private Vector3 LocalToWorld(Vector3 localCoord)
    {
        Vector3 pos = transform.position;
        pos += localCoord.x * transform.right;
        pos += localCoord.y * transform.up;
        return pos;
    }

    private void Reflection()
    {
        Vector2 origin = a.position;
        Vector2 dir = a.transform.right;
        Ray ray = new Ray(origin, dir);
       // dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;

        for (int i = 0; i < maxReflect; i++)
        {

            if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f, surLayer))
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(hitInfo.point, 0.1f);
                Vector2 reflect = Reflect(ray.direction,hitInfo.normal);
                Gizmos.color = Color.green;
                Gizmos.DrawLine(ray.origin,hitInfo.point);
                ray.origin = hitInfo.point;
                ray.direction = reflect;

                Debug.Log($"Reflection {i}: Direction = {dir}, Hit Point = {origin}");
            }
            else
            {
                Debug.Log("1");
                break;
            }



        }

    }

    private Vector3 Reflect(Vector3 inDir,Vector3 normal)
    {
        float proj = Vector2.Dot(inDir, normal);
        return inDir - 2 * proj * normal;
    }

    private void RadialTrigger(Vector2 aPos, Vector2 bPos)
    {
        Vector3 c = bPos - aPos;
        float sqrDist = c.x * c.x + c.y * c.y + c.z * c.z; // is much performant
        
        bool inside = sqrDist <= radius * radius;
        Gizmos.color = inside ? Color.cyan : Color.red;

        Gizmos.DrawWireSphere(bPos, radius);

        // if (Distance(aPos, bPos) < radius)
        // {
        //     Gizmos.DrawSphere(aPos, 0.5f);
        // }
        // else
        // {
        //     Gizmos.DrawSphere(bPos, 0.5f);
        // }
    }



    private float Distance(Vector3 a, Vector3 b)
    {
        Vector3 c = b - a;
        return Mathf.Sqrt(c.x * c.x + c.y * c.y + c.z * c.z);
    }

    private void Lecture1(Vector2 aPos, Vector2 bPos)
    {


        Gizmos.color = Color.blue;
        Gizmos.DrawLine(default, aPos);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(default, bPos);


        float aMag = Mathf.Sqrt(aPos.x * aPos.x + aPos.y * aPos.y);
        Vector2 aNormManual = aPos / aMag;
        Vector2 aNormInbuilt = aPos.normalized;
        Gizmos.DrawSphere(aNormInbuilt, 0.1f);
        aNorm = aNormInbuilt;

        //scalar projection
        sclProj = Vector2.Dot(aNorm, bPos);

        //vector projection
        Vector2 vectorProj = aNorm * sclProj;

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(vectorProj, 0.1f);
    }
}
