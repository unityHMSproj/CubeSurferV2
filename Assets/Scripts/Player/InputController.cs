using UnityEngine;

public class InputController : MonoBehaviour
{
    private float horizontalValue;

    public float HorizontalValue
    {
        get { return horizontalValue; }
    }

    private void Update()
    {
        HorizontalMovement();
    }

    public void HorizontalMovement()
    {
        if (Input.GetMouseButton(0))
        {
            horizontalValue = Input.GetAxis("Mouse X");
        }
        else
            horizontalValue = 0;
    }
}
