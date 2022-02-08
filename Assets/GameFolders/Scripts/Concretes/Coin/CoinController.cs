using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] GameObject goldPicture;
    [SerializeField] Coin[] coins;


    bool isTrigger;

    int currentCollect;

    private void OnEnable()
    {
        foreach (Coin coin in coins)
        {
            coin.gameObject.SetActive(false);
            coin.transform.localPosition = Vector3.zero;
        }
        goldPicture.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Constants.Tags.PLAYER))
        {
            isTrigger = true;

            foreach (Coin coin in coins)
            {
                coin.gameObject.SetActive(true);
            }
            goldPicture.SetActive(false);
        }
    }

    void Update()
    {
        if (!isTrigger) return;

        CheckCoins();
       
    }

    void CheckCoins()
    {
        foreach (Coin coin in coins)
        {
            if (coin.IsCollected)
            {
                currentCollect++;
            }
        }

        if (currentCollect < coins.Length)
        {
            currentCollect = 0;
        }
        else
        {
            ResetCoinSystem();
        }
    }

    void ResetCoinSystem()
    {
        isTrigger = false;
        currentCollect = 0;
        foreach (Coin coin in coins)
        {
            coin.gameObject.SetActive(false);
            coin.transform.localPosition = Vector3.zero;

        }
    }
}
