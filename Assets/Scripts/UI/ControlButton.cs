using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlButton : MonoBehaviour
{
    
    public void GoToControls()
    {
        SceneManager.LoadScene("Controls"); 
    }
}

