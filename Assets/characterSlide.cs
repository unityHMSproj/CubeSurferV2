using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class characterSlide : MonoBehaviour
{
    public static characterSlide instance;
    public TextMeshProUGUI charinfoText;
    public TextMeshProUGUI charCount;
    public List<GameObject> charList;

    public GameObject lockscreen;
    public GameObject lockimage;

    public int id;
    void Awake()
    {
        //Singleton method
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        updateUnlockedCharCount();
        id = 0;
    }

    private void updateUnlockedCharCount()
    {
        int unlockedcount = 0;
        foreach (GameObject modl in charList)
        {
            if (modl.transform.tag == "open")
            {
                unlockedcount++;
            }
        }
        charCount.text = unlockedcount.ToString();
    }
    //3 4 5 6 7 locked

    //3 finish game 3 times to unlock this character
    //4 pay to unlock
    //5 watch ad to unlock
    //6 pay to unlock
    //7 pay to unlock
    public void buttonPressed()
    {
        switch (id)
        {
            case 3:
                charinfoText.text = "Finish game 3 times to unlock";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                break;
            case 4:
                charinfoText.text = "Pay to unlock";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                break;
            case 5:
                charinfoText.text = "Watch ad to unlock";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                break;
            case 6:
                charinfoText.text = "Pay to unlock";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                break;
            case 7:
                charinfoText.text = "Pay to unlock";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                break;
            case 8:
                charinfoText.text = "Coming soon...";
                lockimage.SetActive(false);
                break;
            default:
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                charinfoText.text = "";
                break;
        }
    }
    public void slideRight()
    {
        if (id < 8)
        {

            id++;
            locked(charList[id]);
            foreach (GameObject model in charList)
            {
                model.transform.position = new Vector3(model.transform.position.x + 5f, model.transform.position.y, model.transform.position.z);
            }
        }
    }
    public void slideLeft()
    {

        if (id > 0)
        {
            id--;
            locked(charList[id]);
            foreach (GameObject model in charList)
            {
                model.transform.position = new Vector3(model.transform.position.x - 5f, model.transform.position.y, model.transform.position.z);
            }
        }
    }

    public void locked(GameObject model)
    {   //karakterler bende kayıyor onun harici sorun yok ama belki sendede siyah ekran kaymıs olabılır


        if (model.CompareTag("locked"))
        {
            lockscreen.gameObject.SetActive(true);
        }
        else
        {
            lockscreen.gameObject.SetActive(false);
        }


    }
    

}

