using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Barrel : MonoBehaviour
{
    [Range(1f,10f)]
    public float radius =1;
    public float damage;
    public Color color = Color.blue;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);       
    }


    private void OnEnable() => BarrelManager.allBarrels.Add(this);
    private void OnDisable() => BarrelManager.allBarrels.Remove(this);
}
