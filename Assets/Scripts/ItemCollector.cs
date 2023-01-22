using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{   
    private int money = 0;
    private int cards = 0;

    [SerializeField] private TextMeshProUGUI Counter;
    [SerializeField] private TextMeshProUGUI Counter2;

    [SerializeField] private AudioSource moneyCollectSoundEffect;
    [SerializeField] private AudioSource cardCollectSoundEffect;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Money")){
            Destroy(collision.gameObject);
            money++;
            Counter.text = "Money: " + money + "\n";
            moneyCollectSoundEffect.Play();
        }
        else if(collision.gameObject.CompareTag("Cards")){
            Destroy(collision.gameObject);
            cards++;
            Counter2.text = "Cards: " + cards;
            cardCollectSoundEffect.Play();
        }
    }
}
