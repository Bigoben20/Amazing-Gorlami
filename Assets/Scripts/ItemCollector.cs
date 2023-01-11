using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{   
    private int money = 0;
    private int cards = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable")){
            Destroy(collision.gameObject);
            money++;
        }
    }
}
