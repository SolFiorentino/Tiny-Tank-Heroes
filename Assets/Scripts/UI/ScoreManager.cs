using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    private int score = 0;
    private int winScore = 10; // El número de objetivos necesarios para ganar

    void Awake()
    {
        // Singleton pattern para asegurarse de que solo haya una instancia de ScoreManager
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
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();

        // Verifica si el jugador ha alcanzado el puntaje de victoria
        if (score >= winScore)
        {
            LoadVictoryScene();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Targets Hit: " + score;
    }

    void LoadVictoryScene()
    {
        SceneManager.LoadScene("Screen Level 2"); // Asegúrate de que el nombre de la escena de victoria sea correcto
    }
}

