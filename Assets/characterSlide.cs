using TMPro;
using System.Collections.Generic;
using UnityEngine;
using HmsPlugin;

public class characterSlide : MonoBehaviour
{
    public static characterSlide instance;
    public TextMeshProUGUI charinfoText;
    public TextMeshProUGUI charCount;
    public List<GameObject> charList;
    private bool boss_locked = true;

    public GameObject lockscreen;
    public GameObject lockimage;
    public GameObject actionButton;
    public TextMeshProUGUI actionButtonText;
    public GameObject goButton;

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
        charCount.text = unlockedcount.ToString() + " of 9 characters are unlocked";
    }

    public void buttonPressed()
    {
        switch (id)
        {
            case 2:
                charinfoText.text = "150 Coins";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                showActionButton();
                actionButtonText.text = "Pay";
                break;
            case 3:
                charinfoText.text = "500 Coins";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                showActionButton();

                actionButtonText.text = "Pay";

                break;
            case 4:
                charinfoText.text = "1500 Coins";
                if (!lockimage.activeSelf) lockimage.SetActive(true);
                showActionButton();

                actionButtonText.text = "Pay";


                break;
            case 5:
                if (GameObject.Find("5").transform.tag == "open")
                {
                    charinfoText.text = "";
                    showPlayButton();
                    if (lockimage.activeSelf) lockimage.SetActive(false);
                }
                else if (GameObject.Find("5").transform.tag == "locked")
                {
                    charinfoText.text = "Watch ad to unlock";

                    showActionButton();

                    actionButtonText.text = "Watch Ad";
                    if (!lockimage.activeSelf) lockimage.SetActive(true);
                }
                break;
            case 6:
                if (GameObject.Find("6").transform.tag == "open")
                {
                    charinfoText.text = "";
                    showPlayButton();
                    if (lockimage.activeSelf) lockimage.SetActive(false);
                }
                else if (GameObject.Find("6").transform.tag == "locked")
                {
                    charinfoText.text = "Watch ad to unlock";

                    showActionButton();

                    actionButtonText.text = "Watch Ad";
                    if (!lockimage.activeSelf) lockimage.SetActive(true);
                }


                break;
            case 7:
                if (boss_locked)
                {
                    charinfoText.text = "Purchase to unlock";
                    if (!lockimage.activeSelf) lockimage.SetActive(true);
                    showActionButton();

                    actionButtonText.text = "Purchase";
                }
                else
                {
                    charinfoText.text = "";
                    if (lockimage.activeSelf) lockimage.SetActive(false);
                    if (lockscreen.activeSelf) lockscreen.SetActive(false);
                    showPlayButton();

                }
                break;
            case 8:
                charinfoText.text = "Coming soon...";
                lockimage.SetActive(false);
                if (actionButton.activeSelf) actionButton.SetActive(false);
                if (goButton.activeSelf) actionButton.SetActive(false);

                break;
            default:
                //for id = 0 and 1;
                if (lockimage.activeSelf) lockimage.SetActive(false);
                showPlayButton();
                charinfoText.text = "";
                break;
        }
    }
    public void unlock()
    {

        Debug.Log(id);
        if (id == 5)
        {
            var model = GameObject.Find("5");
            model.transform.tag = "open";
            lockscreen.SetActive(false);
            lockimage.SetActive(false);
            charinfoText.text = "";
            showPlayButton();

        }

        if (id == 6)
        {
            var model = GameObject.Find("6");
            model.transform.tag = "open";
            lockscreen.SetActive(false);
            lockimage.SetActive(false);
            charinfoText.text = "";
            showPlayButton();

        }
        updateUnlockedCharCount();
    }
    public void showActionButton()
    {
        if (goButton.activeSelf) goButton.SetActive(false);
        if (!actionButton.activeSelf) actionButton.SetActive(true);
    }
    public void showPlayButton()
    {
        if (actionButton.activeSelf) actionButton.SetActive(false);
        if (!goButton.activeSelf) goButton.SetActive(true);
    }

    public void action()
    {
        switch (id)
        {
            case 2:
                // charinfoText.text = "150 Coins";

                break;
            case 3:
                // charinfoText.text = "500 Coins";

                break;
            case 4:
                // charinfoText.text = "1500 Coins";


                break;
            case 5:

                admanager.Instance.ShowRewardedAd();

                break;
            case 6:

                admanager.Instance.ShowRewardedAd();
                break;
            case 7:
                // charinfoText.text = "Purchase to unlock";
                iapmanager.Instance.PurchaseProduct("theboss_char");

                break;
            default:
                break;
        }
    }

    public void buyCharacter(int id)
    {
        GameObject.Find(id.ToString()).transform.tag = "open";
        showPlayButton();
        lockscreen.SetActive(false);
        lockimage.SetActive(false);
        charinfoText.text = "";

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

