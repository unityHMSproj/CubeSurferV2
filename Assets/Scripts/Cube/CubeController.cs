using UnityEngine;
using System.Collections.Generic;
public class CubeController : MonoBehaviour
{

    [Header("Layer Mask")]
    [SerializeField] private LayerMask voidLM;
    [SerializeField] private LayerMask finishLM;
    [SerializeField] private GameObject stackControllerobj;
    [Header("Animation")]
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
        stackControllerobj = GameObject.Find("Player");
        rand = Random.Range(0, popSoundList.Count);
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
            Debug.DrawRay(new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z), Vector3.down * 1.2f, Color.red);
            Debug.DrawRay(new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z), Vector3.down * 1.2f, Color.red);
        }
        setRayCast();
        setBottomRayCast();
    }

    private void setRayCast()
    {
        if (Physics.Raycast(new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z), direction, out hit, 1f)
        || Physics.Raycast(new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z), direction, out hit, 1f)
        || Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z), direction, out hit, 1f)
        || Physics.Raycast(new Vector3(transform.position.x, transform.position.y - 0.9f, transform.position.z), direction, out hit, 1f))
        {
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
            if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f), Vector3.down, out hit, 1.5f) &&
    Physics.Raycast(new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f), Vector3.down, out hit, 1.5f) &&
    Physics.Raycast(new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z), Vector3.down, out hit, 1.5f) &&
    Physics.Raycast(new Vector3(transform.position.x + 0.8f, transform.position.y, transform.position.z), Vector3.down, out hit, 1.5f))
            {
                if (hit.transform.name == "finish2")
                {
                    if (!stackControllerobj.GetComponent<StackController>().isFinished)
                    {
                        stackControllerobj.GetComponent<StackController>().finishGame(StackController.instance.currentscore, 10);
                    }
                }
                if (hit.transform.tag == "void")
                {
                    Debug.Log("SaveScore");
                    stackControllerobj.GetComponent<StackController>().VoidStack(gameObject);
                }
            }


        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (Last)
        {
            if (other.transform.tag == "coin")
            {
                StackController.instance.currentscore++;
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