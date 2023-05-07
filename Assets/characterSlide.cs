using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterSlide : MonoBehaviour
{
    public List<GameObject> charList;
    private int counter;
    void Start()
    {
        counter = 0;
    }

    public void slideRight()
    {
        if (counter < 7)
        {
            Debug.Log("sa");
            counter++;
            foreach (GameObject model in charList)
            {
                model.transform.position = new Vector3(model.transform.position.x + 4.80f, model.transform.position.y, model.transform.position.z);
            }
        }
    }
    public void slideLeft()
    {
        if (counter > 0)
        {
            counter--;

            foreach (GameObject model in charList)
            {
                model.transform.position = new Vector3(model.transform.position.x - 4.80f, model.transform.position.y, model.transform.position.z);
            }
        }
    }
}
