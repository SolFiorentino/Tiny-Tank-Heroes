using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Incrementar el contador de monedas
            CoinManager.instance.IncrementCoinCount();

            // Destruir la moneda
            Destroy(gameObject);
        }
    }
}

