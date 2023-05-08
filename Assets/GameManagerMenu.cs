using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public sceneLoader loader;
    public void startGame(){
        loader.LoadNextLevel();
    }
    public void exitGame(){
        Application.Quit();
    }
}
