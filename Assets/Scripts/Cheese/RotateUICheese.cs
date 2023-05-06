using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUICheese : MonoBehaviour
{

    [SerializeField] float rotateSpeedX;

    [SerializeField] float rotateSpeedY;

    [SerializeField] float rotateSpeedZ;
    void Update()
    {
        transform.Rotate(
            360 * rotateSpeedX * Time.deltaTime,
            360 * rotateSpeedY * Time.deltaTime,
            360 * rotateSpeedZ * Time.deltaTime
        );
    }
}
