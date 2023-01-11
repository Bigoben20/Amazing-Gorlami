using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{   
    private int money = 0;
    private int cards = 0;

    [SerializeField] private TextMeshProUGUI MoneyCount;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable")){
            Destroy(collision.gameObject);
            money++;
            MoneyCount.text = "Money: " + money;
        }
    }
}
