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
        actualLife = maximumLife; // Asegúrate de que la vida inicial sea igual a la vida máxima
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
            // Aquí puedes manejar la lógica de muerte del jugador, si es necesario
            Debug.Log("Jugador ha muerto");
            SceneManager.LoadScene("Defeat"); // Asegúrate de que el nombre de la escena de derrota sea correcto
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



