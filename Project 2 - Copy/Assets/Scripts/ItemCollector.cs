using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int coincount = 0;

    [SerializeField]
    private Text CoinCount;

    [SerializeField]
    private GameObject GoldenPlatform;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coincount++;
            CoinCount.text = "Coins: " + coincount;

        }
        if (coincount == 6)
        {
            GoldenPlatform.SetActive(true);
        }
    }



}
