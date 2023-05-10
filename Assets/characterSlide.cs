using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlide : MonoBehaviour
{
    public static characterSlide instance;
    public List<GameObject> charList;

    public GameObject lockscreen;

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
        id = 0;

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

