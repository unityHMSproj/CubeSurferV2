using UnityEngine;
using System.Collections.Generic;
public class CubeController : MonoBehaviour
{

    [Header("Layer Mask")]
    [SerializeField] private LayerMask voidLM;
    [SerializeField] private LayerMask finishLM;
    [SerializeField] private GameObject stackControllerobj;
    [Header("Animation")]
    [SerializeField] private GameObject mouse;
    private Vector3 direction = Vector3.back;
    private RaycastHit hit;
    [Header("Bool")]
    public bool Last = false;
    private bool isPushed = false;
    [Header("Audio")]
    public AudioSource collectSound;

    int rand;

    public List<AudioSource> popSoundList = new List<AudioSource>();


    private void Start()
    {
        rand = Random.Range(0, popSoundList.Count);
        Debug.Log(popSoundList.Count);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Forward raycasts
        Debug.DrawRay(new Vector3(transform.position.x - 0.9f, transform.position.y, transform.position.z), direction * 1.1f, Color.cyan);
        Debug.DrawRay(new Vector3(transform.position.x + 0.9f, transform.position.y, transform.position.z), direction * 1.1f, Color.cyan);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), direction * 1.1f, Color.cyan);
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z), direction * 1.1f, Color.cyan);
        //Bottom raycast
        if (Last)
        {
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Vector3.down * 1.2f, Color.red);
            Debug.DrawRay(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Vector3.down * 1.2f, Color.red);
            Debug.DrawRay(new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z), Vector3.down * 1.2f, Color.red);
            Debug.DrawRay(new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z), Vector3.down * 1.2f, Color.red);
        }
        setRayCast();
        setBottomRayCast();
    }

    private void setRayCast()
    {
        if (Physics.Raycast(new Vector3(transform.position.x - 0.9f, transform.position.y, transform.position.z), direction, out hit, 1f)
        || Physics.Raycast(new Vector3(transform.position.x + 0.9f, transform.position.y, transform.position.z), direction, out hit, 1f)
        || Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), direction, out hit, 1f)
        || Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z), direction, out hit, 1f))
        {
            // Debug.Log("raycash hitted!");
            if (!isPushed)
            {
                setDir();
                stackControllerobj.GetComponent<StackController>().PushStack(gameObject);
                popSoundList[rand].Play();
                isPushed = true;
            }

            if (hit.transform.tag == "obstacle"
            || hit.transform.tag == "platformFinish1x"
            || hit.transform.tag == "platformFinish2x"
            || hit.transform.tag == "platformFinish4x"
            || hit.transform.tag == "platformFinish6x"
            || hit.transform.tag == "platformFinish10x")
            {
                stackControllerobj.GetComponent<StackController>().PopStack(gameObject);
            }

        }
    }

    public void setBottomRayCast()
    {
        if (Last)
        {

            //finish line raycast
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Vector3.down, out hit, 1.1f) &&
            Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Vector3.down, out hit, 1.1f)
            )
            {
                if (hit.transform.name == "finish1")
                {
                    mouse.GetComponent<Animator>().SetBool("isFinished", true);

                }
                if (hit.transform.name == "finish2")
                {
                    if (!stackControllerobj.GetComponent<StackController>().isFinished)
                    {

                        stackControllerobj.GetComponent<StackController>().finishGame(10);
                    }
                }
            }

            if
            (
                Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.9f), Vector3.down, out hit, 1.2f) &&
                Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.9f), Vector3.down, out hit, 1.2f) &&
                Physics.Raycast(new Vector3(transform.position.x - 0.9f, transform.position.y, transform.position.z), Vector3.down, out hit, 1.2f) &&
                Physics.Raycast(new Vector3(transform.position.x + 0.9f, transform.position.y, transform.position.z), Vector3.down, out hit, 1.2f)
            )
            {
                if (hit.transform.name == "void")
                {
                    stackControllerobj.GetComponent<StackController>().VoidStack(gameObject);
                }
            };
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Last)
        {
            if (other.transform.tag == "cheese")
            {
                collectSound.Play();
                other.transform.gameObject.GetComponent<Cheese>().collectCheese();
                Destroy(other.transform.gameObject);
            }
        }
    }

    public void setDir()
    {
        direction = Vector3.forward;
    }
}