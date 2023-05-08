using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class gamemanagerSelect : MonoBehaviour
{
    public TextMeshProUGUI text;
    public sceneLoader loader;

    private void Start()
    {
        text.SetText((PlayerPrefs.GetInt("cheese")).ToString());
    }
    public void goBack()
    {
        SceneManager.LoadScene(0);
    }
    public void play()
    {
        loader.LoadNextLevel();
    }
}
