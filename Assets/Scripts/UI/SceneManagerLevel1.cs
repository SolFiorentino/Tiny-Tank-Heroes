using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerLevel1: MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Game"); // Aseg�rate de que el nombre de la escena del juego sea correcto

    }


}
