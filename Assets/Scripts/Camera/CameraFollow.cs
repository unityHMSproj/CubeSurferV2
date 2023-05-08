using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private float deltaZ;
    private float deltaY;
    private float beginY;
    private float newY;
    private Vector3 newPosition;
    [SerializeField] private float lerpvalue;
    [SerializeField] private AudioSource bgMusic;
    public int targetFrameRate = 120;
    public bool finished;

    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        deltaZ = transform.position.z - playerTransform.position.z;
        deltaY = transform.position.y - playerTransform.position.y;
        beginY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()

    {

        if (!finished)
        {
            beginY = transform.position.y;
            newY = playerTransform.position.y + deltaY;
            newPosition = Vector3.Lerp(transform.position, new Vector3(transform.position.x, newY, playerTransform.position.z + deltaZ), lerpvalue);
            transform.position = newPosition;
            var newDeltaY = beginY - newY;

            var rotateX = -1f * newDeltaY * 360 * (Time.fixedDeltaTime) / 8;

            transform.Rotate(rotateX, 0, 0);


        }



    }
}

