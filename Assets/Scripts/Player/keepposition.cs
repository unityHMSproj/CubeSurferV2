using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepposition : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 31.32f, transform.position.z);
    }
}
