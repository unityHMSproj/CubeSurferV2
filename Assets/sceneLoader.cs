using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public void LoadScene(string mode)
    {
        if (mode == "mainmenu")
        {
            StartCoroutine(LoadLevel(0));
        }
        if (mode == "previous")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }
        if (mode == "next")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        if (mode == "restart")
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }


    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Change");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }
}
