using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ProceduralMesh : MonoBehaviour
{

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;


    private void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }
    void Update()
    {
        MakeMeshData();
        CreateMesh();
    }


    private void MakeMeshData()
    {
        vertices = new Vector3[] { new Vector3(0, YValue.instance.yValueToChange, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1) };
        triangles = new int[] { 0, 1, 2, 1, 3, 2 };
    }

    private void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }


}
