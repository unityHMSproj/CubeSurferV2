using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlide : MonoBehaviour
{
    public static characterSlide instance;
    public List<GameObject> charList;

    public GameObject lockscreen;

    public float x_coor;
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
        x_coor = lockscreen.transform.position.x;

    }

    public void slideRight()
    {
        if (id < 7)
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

     public void locked(GameObject model){   //karakterler bende kayıyor onun harici sorun yok ama belki sendede siyah ekran kaymıs olabılır


        if (model.CompareTag("locked"))
            {
            lockscreen.transform.position = new Vector3(x_coor - 7f, lockscreen.transform.position.y, lockscreen.transform.position.z);
        }
        else
            {
            lockscreen.transform.position = new Vector3(x_coor , lockscreen.transform.position.y, lockscreen.transform.position.z);
                }
    

}}

