using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeBarController : MonoBehaviour
{
    public Image lifeBar;
    public float actualLife;
    public float maximumLife;

    void Start()
    {
        actualLife = maximumLife; // Aseg�rate de que la vida inicial sea igual a la vida m�xima
    }

    void Update()
    {
        lifeBar.fillAmount = actualLife / maximumLife;
    }

    public void TakeDamage(float amount)
    {
        actualLife -= amount;
        if (actualLife <= 0)
        {
            actualLife = 0;
            // Aqu� puedes manejar la l�gica de muerte del jugador, si es necesario
            Debug.Log("Jugador ha muerto");
            SceneManager.LoadScene("Defeat"); // Aseg�rate de que el nombre de la escena de derrota sea correcto
        }
    }

    public void Heal(float amount)
    {
        actualLife += amount;
        if (actualLife > maximumLife)
        {
            actualLife = maximumLife;
        }
    }
}



