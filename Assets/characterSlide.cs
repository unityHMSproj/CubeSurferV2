using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlide : MonoBehaviour
{
    public List<GameObject> charList;
    [SerializeField] private int id;
    void Start()
    {
        id = 0;
    }

    public void slideRight()
    {
        if (id < 7)
        {
            Debug.Log("sa");
            id++;
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

            foreach (GameObject model in charList)
            {
                model.transform.position = new Vector3(model.transform.position.x - 5f, model.transform.position.y, model.transform.position.z);
            }
        }
    }
}
