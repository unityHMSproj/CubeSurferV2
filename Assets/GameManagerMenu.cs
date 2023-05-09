using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public sceneLoader loader;
    public void startGame()
    {
        loader.LoadScene("next");

    }
    public void exitGame()
    {
        Application.Quit();
    }
}
