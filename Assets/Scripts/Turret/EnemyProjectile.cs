using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage = 10f;
    public float lifeTime = 5f; // Tiempo de vida del proyectil en segundos

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destruir el proyectil después de `lifeTime` segundos
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reducir la vida del jugador
            LifeBarController playerLife = collision.gameObject.GetComponent<LifeBarController>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }
        }

        // Destruir el proyectil al impactar con cualquier objeto
        Destroy(gameObject);
    }
}


