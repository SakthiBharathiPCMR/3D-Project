using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
            Vector3 startPos = transform.position;
            Vector3 endPos = allBarrels[i].transform.position;
            float halfHeight = (startPos.y - endPos.y) * 0.5f;
            Vector3 offset = Vector3.up * halfHeight;

            Handles.DrawBezier(startPos, endPos, startPos - offset, endPos + offset, Color.blue, EditorGUIUtility.whiteTexture, 1f);
            //Handles.DrawAAPolyLine(transform.position, allBarrels[i].transform.position);
        }
    }

#endif


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
