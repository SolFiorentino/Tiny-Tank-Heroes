using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cargar escenas

public class EnemyScoreManager : MonoBehaviour
{
    public static EnemyScoreManager instance;
    public Text enemyScoreText;
    private int enemyScore = 0;
    private int winEnemyScore = 2; // El número de enemigos necesarios para ganar

    void Awake()
    {
        // Singleton pattern para asegurarse de que solo haya una instancia de EnemyScoreManager
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
        UpdateEnemyScoreText();
    }

    public void IncrementEnemyScore()
    {
        enemyScore++;
        UpdateEnemyScoreText();

        // Verifica si el jugador ha alcanzado el puntaje de victoria
        if (enemyScore >= winEnemyScore)
        {
            LoadVictoryScene();
        }
    }

    void UpdateEnemyScoreText()
    {
        enemyScoreText.text = "Enemies Destroyed: " + enemyScore;
    }

    void LoadVictoryScene()
    {
        SceneManager.LoadScene("Screen Level 3"); // Asegúrate de que el nombre de la escena de victoria sea correcto
    }
}

