using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public float healthBoost = 50f; // Cantidad de salud que aumenta
    public AudioClip powerUpSoundClip; // Clip de audio del power-up
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = powerUpSoundClip;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeBarController playerLife = other.GetComponent<LifeBarController>();
            if (playerLife != null)
            {
                playerLife.Heal(healthBoost);
            }

            // Reproducir sonido del power-up
            if (audioSource != null && powerUpSoundClip != null)
            {
                audioSource.Play();
                // Destruir el power-up después de que el sonido termine de reproducirse
                Destroy(gameObject, powerUpSoundClip.length);
            }
            else
            {
                // Si no hay audio, destruir el objeto inmediatamente
                Destroy(gameObject);
            }
        }
    }
}



