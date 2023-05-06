using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{

    [SerializeField] float rotateSpeedX;

    [SerializeField] float rotateSpeedY;

    [SerializeField] float rotateSpeedZ;
    Vector3 startpos;
    Vector3 endpos;
    private bool isCollected;
    private void Start()
    {
        startpos = transform.position;
        endpos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            360 * rotateSpeedX * Time.deltaTime,
            360 * rotateSpeedY * Time.deltaTime,
            360 * rotateSpeedZ * Time.deltaTime
        );
    }
    public void collectCheese()
    {
        isCollected = true;
        PlayerPrefs.SetInt("cheese",PlayerPrefs.GetInt("cheese")+1);
    }
}
