using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void MainMenuClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
