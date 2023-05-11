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
    public sceneLoader loader;

    public static int Points;

    void Start()
    {
        int charId = characterSlide.instance.id;
        Time.timeScale = 0;
        model = GameObject.Find(charId.ToString());
        modelDefaultPos = model.transform.position;
        model.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 1, Player.transform.position.z);
        model.transform.SetParent(Player.transform);
        StackController.instance.isOver = true;
    }

    public void PressStart()
    {
        StackController.instance.isOver = false;
        Time.timeScale = 1;

        startmenu.gameObject.SetActive(false);
        gamemenu.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        loader.LoadScene("restart");

    }

    public void PassLevel1()

    {
        loader.LoadScene("next");
    }
    public void PassLevel2()
    {
        loader.LoadScene("previous");

    }

    public void mainmenu()
    {
        Time.timeScale = 1;
        loader.LoadScene("mainmenu");

    }

    public void pausegame()
    {
        if (Time.timeScale != 0) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
