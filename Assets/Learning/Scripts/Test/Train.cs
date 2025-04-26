
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{

    internal void FillColor()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
