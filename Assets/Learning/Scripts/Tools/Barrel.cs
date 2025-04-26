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

    int shaderColId = Shader.PropertyToID("_Color");

    MaterialPropertyBlock matPropBlock;
    public MaterialPropertyBlock MatPropBlock
    {
        get
        {
            if(matPropBlock == null)
            {
                matPropBlock = new MaterialPropertyBlock();
            }
            return matPropBlock;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radius);       
    }

    void ApplyColor()
    {
        MeshRenderer render = GetComponent<MeshRenderer>();
        MatPropBlock.SetColor(shaderColId, color);
        render.SetPropertyBlock(MatPropBlock);
    }

    private void OnValidate()
    {
        ApplyColor();
    }

    private void OnEnable()
    {
        ApplyColor();
        BarrelManager.allBarrels.Add(this);
    }
    private void OnDisable() => BarrelManager.allBarrels.Remove(this);
}
