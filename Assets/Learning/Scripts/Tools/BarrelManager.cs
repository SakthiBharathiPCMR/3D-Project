using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class BarrelManager : MonoBehaviour
{
    public static List<Barrel> allBarrels = new List<Barrel>();

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        for(int i= 0; i< allBarrels.Count; i++)
        {
            Handles.DrawAAPolyLine(transform.position, allBarrels[i].transform.position);
        }
    }

#endif
}
