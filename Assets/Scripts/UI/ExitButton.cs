using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // Este m�todo se llamar� al presionar el bot�n
    public void ExitGame()
    {
        // Para cerrar el juego en una build
        Application.Quit();

        // Para cerrar el juego en el editor de Unity (solo funciona en el editor)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

