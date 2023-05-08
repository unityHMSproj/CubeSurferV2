using UnityEngine.SceneManagement;
using UnityEngine;

public class gamemanagerSelect : MonoBehaviour
{
    public void goBack()
    {
        SceneManager.LoadScene(0);
    }
    public void play()
    {
        SceneManager.LoadScene(2);
    }
}
