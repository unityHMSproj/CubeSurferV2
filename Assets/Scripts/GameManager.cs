using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject startmenu;
    [SerializeField] GameObject gamemenu;

    public static int Points;

    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update() { }

    public void PressStart()
    {
        Time.timeScale = 1f;
        startmenu.gameObject.SetActive(false);
        gamemenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void PassLevel1()
    {
        SceneManager.LoadScene(2);
    }
    public void PassLevel2()
    {
        SceneManager.LoadScene(1);
    }

    public void mainmenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void pausegame()
    {
        if (Time.timeScale != 0) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
