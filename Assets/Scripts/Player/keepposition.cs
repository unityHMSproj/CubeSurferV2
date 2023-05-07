using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepposition : MonoBehaviour
{

    public void setPos(float newY)
    {
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
