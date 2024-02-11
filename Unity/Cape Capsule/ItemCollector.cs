using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] Text coinsText;
    //had to use Ontrigger rather OnCollision as we will check  the IsTrigger functionality for all collectibles
    //so that we can pass through them rather than sticking onto their surface
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text="Coins:" + coins;
        }
    }
}
