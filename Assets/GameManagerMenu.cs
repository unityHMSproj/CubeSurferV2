using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMenu : MonoBehaviour
{
    public sceneLoader loader;
    public GameObject card;
    public void startGame()
    {
        loader.LoadScene("next");

    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void showCard(){
        card.SetActive(true);
    }
    public void hideCard(){
        card.SetActive(false);

    }
}
