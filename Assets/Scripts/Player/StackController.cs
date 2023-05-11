using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StackController : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject RetryButton;
    [SerializeField] private GameObject NextLevelButton;
    [SerializeField] private GameObject menubutton;
    [SerializeField] private GameObject trailObj;
    public static StackController instance;
    public List<GameObject> cubelist = new List<GameObject>();
    private GameObject lastCube;
    private RaycastHit hit;
    public bool isOver = false;
    public bool isFinished;
    public AudioSource collectSound;
    public int currentscore = 0;
    private keepposition trail;

    [Header("Camera")]
    [SerializeField] private Camera cam;
    public GameObject centerRotate;
    public Vector3 axis;

    void Start()
    {
        instance = this;
        trailObj.transform.position = new Vector3(trailObj.transform.position.x, (cubelist[cubelist.Count - 1].transform.position.y - 0.1f), trailObj.transform.position.z);
        UpdateLastCube();
    }

    void Update()
    {
        setRayCast();
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.forward * 1.1f, Color.red);

        if (isFinished)
        {
            cam.transform.RotateAround(centerRotate.transform.position, axis, 0.5f);
        }
    }

    public void PushStack(GameObject gameobj)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        gameobj.transform.position = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y - 2f, lastCube.transform.position.z);
        gameobj.transform.SetParent(transform);
        gameobj.AddComponent<Rigidbody>();
        gameobj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        gameobj.GetComponent<BoxCollider>().material.bounciness = 0f;
        cubelist.Add(gameobj);
        UpdateLastCube();
        // transform.position.y-((cubelist.count-1)*30)
        trailObj.transform.position = new Vector3(trailObj.transform.position.x, (cubelist[cubelist.Count - 1].transform.position.y - 0.1f), trailObj.transform.position.z);
    }

    public void PopStack(GameObject gameobj)
    {
        // Debug.Log("popped from stack");
        gameobj.transform.parent = null;
        cubelist.Remove(gameobj);
        UpdateLastCube();
        trailObj.transform.position = new Vector3(trailObj.transform.position.x, (cubelist[cubelist.Count - 1].transform.position.y - 0.1f), trailObj.transform.position.z);
    }

    public void VoidStack(GameObject gameobj)
    {
        gameobj.transform.parent = null;
        gameobj.GetComponent<BoxCollider>().isTrigger = true;
        cubelist.Remove(gameobj);
        Destroy(gameobj, 2f);
        UpdateLastCube();
    }

    private void UpdateLastCube()
    {
        if (cubelist.Count == 0)
            lastCube = null;
        else
        {
            lastCube = cubelist[cubelist.Count - 1];

            if (cubelist.Count == 2)
            {
                cubelist[1].GetComponent<CubeController>().Last = true;
            }
            else if (cubelist.Count > 2)
            {
                cubelist[cubelist.Count - 1].GetComponent<CubeController>().Last = true;
                cubelist[cubelist.Count - 2].GetComponent<CubeController>().Last = false;
            }
        }
    }

    private void setRayCast()
    {
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z), Vector3.forward, out hit, 1.1f)
        )
        {
            if (hit.transform.tag == "obstacle")
            {
                if (!isOver)
                {
                    GameOver.GetComponent<Animator>().SetTrigger("isgameOver");
                    RetryButton.GetComponent<Animator>().SetTrigger("isGameOver");

                    transform.GetChild(1).GetComponent<Animator>().enabled = false;
                    GetComponent<MovementController>().VerticalMovementSpeed = 0;

                    isOver = true;
                    cam.GetComponent<CameraFollow>().finished = true;
                    menubutton.gameObject.SetActive(true);
                }
            }

            else if (hit.transform.tag == "platformFinish1x")
            {
                if (!isFinished)
                {
                    finishGame(currentscore,1);

                }
            }
            else if (hit.transform.tag == "platformFinish2x")
            {
                if (!isFinished)
                {
                    finishGame(currentscore,2);

                }
            }
            else if (hit.transform.tag == "platformFinish4x")
            {
                if (!isFinished)
                {
                    finishGame(currentscore,4);
                }
            }
            else if (hit.transform.tag == "platformFinish6x")
            {
                if (!isFinished)
                {
                    finishGame(currentscore,6);

                }
            }


        }

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.transform.tag == "coin")
        {
            currentscore++;
            collectSound.Play();
            other.transform.gameObject.GetComponent<Cheese>().collectCheese();
            Destroy(other.transform.gameObject);
        }
        if (other.transform.name == "finish1")
        {
            // transform.GetChild(1).GetComponent<Animator>().SetBool("dance", true);

        }
        if (other.transform.name == "finish2")
        {
            if (!isFinished)
            {
                finishGame(currentscore,10);
            }
        }
        if (other.transform.tag == "void")
        {
            if (!isOver)
            {
                StartCoroutine(voidFail());
            }
        }
    }

    public IEnumerator voidFail()
    {
        //disable collider,
        //wait for 1 sec
        //then finish
        GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        GameOver.GetComponent<Animator>().SetTrigger("isgameOver");
        RetryButton.GetComponent<Animator>().SetTrigger("isGameOver");
        GetComponent<MovementController>().VerticalMovementSpeed = 0;

        isOver = true;
        cam.GetComponent<CameraFollow>().finished = true;
        menubutton.gameObject.SetActive(true);
    }
    public void finishGame(int currentscore, int multiplier)
    {
        GetComponent<MovementController>().VerticalMovementSpeed = 0;
        NextLevelButton.GetComponent<Animator>().SetTrigger("levelFinished");
        cam.GetComponent<CameraFollow>().finished = true;
        PlayerPrefs.SetInt("cheese", PlayerPrefs.GetInt("cheese") + currentscore * multiplier);
        isFinished = true;
    }
}
