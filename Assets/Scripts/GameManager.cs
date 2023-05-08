using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject startmenu;
    [SerializeField] GameObject gamemenu;
    [SerializeField] private GameObject model;
    [SerializeField] private Vector3 modelDefaultPos;
    [SerializeField] private GameObject Player;
    public static int Points;

    void Start()
    {
        int charId = characterSlide.instance.id;

        model = GameObject.Find(charId.ToString());
        modelDefaultPos = model.transform.position;
        model.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);
        model.transform.SetParent(Player.transform);
        Time.timeScale = 0f;
    }

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
