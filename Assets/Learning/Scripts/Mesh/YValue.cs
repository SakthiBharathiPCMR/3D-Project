using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YValue : MonoBehaviour
{
    public float yValueToChange;
    public static YValue instance;

    private void Awake()
    {
        instance = this;
    }
}
