using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);

        GameManager.instance.FoodCollected();
    }
}