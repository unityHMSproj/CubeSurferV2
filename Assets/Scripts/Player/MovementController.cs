using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private InputController inputcontroller;

    [SerializeField]
    private float HorizontalMovementSpeed;

   
    public float VerticalMovementSpeed;

    [SerializeField]
    private float bound;
    private float newPositionX;

    private void FixedUpdate()
    {
        setVerticalSpeed();
        setHorizontalSpeed();
    }

    public void setVerticalSpeed()
    {
        transform.Translate(Vector3.forward * VerticalMovementSpeed * Time.fixedDeltaTime);
    }

    public void setHorizontalSpeed()
    {
        newPositionX =
            transform.position.x
            + inputcontroller.HorizontalValue * HorizontalMovementSpeed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -bound, bound);
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
    }
}
