using UnityEngine;
using System.Collections;


public class GameManagerMenu : MonoBehaviour
{
    public sceneLoader loader;
    public GameObject card;
    public Animator playAnimator;
    public Animator exitAnimator;
    private void Start()
    {
        setButtonAnimations();

    }
    public void startGame()
    {
        
        loader.LoadScene("next");

    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void showCard()
    {
        card.SetActive(true);
    }
    public void hideCard()
    {
        card.SetActive(false);

    }
    public void setButtonAnimations()
    {
        StartCoroutine(x());
    }

    private IEnumerator x()
    {
        playAnimator.SetTrigger("go");
        yield return new WaitForSecondsRealtime(0.2f);
        exitAnimator.SetTrigger("go");
    }
}
