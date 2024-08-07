using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    public Text coinText;
    public AudioSource coinSound; // Agregar referencia al AudioSource

    private int coinCount = 0;
    private int winCoinCount = 10; // El n�mero de monedas necesarias para ganar

    void Awake()
    {
        // Singleton pattern para asegurarse de que solo haya una instancia de CoinManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateCoinText();

        // Aseg�rate de que coinSound est� asignado en el Inspector
        if (coinSound == null)
        {
            Debug.LogError("AudioSource no asignado. Por favor, asigna un AudioSource en el Inspector.");
        }
    }

    public void IncrementCoinCount()
    {
        coinCount++;
        UpdateCoinText();

        // Reproducir sonido de la moneda
        if (coinSound != null)
        {
            coinSound.Play();
        }

        // Verifica si el jugador ha alcanzado el n�mero de monedas necesarias para ganar
        if (coinCount >= winCoinCount)
        {
            LoadVictoryScene();
        }
    }

    void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount;
    }

    void LoadVictoryScene()
    {
        SceneManager.LoadScene("Victory"); // Aseg�rate de que el nombre de la escena de victoria sea correcto
    }
}



