using System.Collections;
using UnityEngine;

public class animcontrol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float startDelay;
    public GameObject playButton;
    public GameObject settingsButton;
    public GameObject exitButton;


    private Animator animator1;
    private Animator animator2;
    private Animator animator3;
   
    private void Awake()
    {
        animator1 = playButton.GetComponent<Animator>();
        animator2 = settingsButton.GetComponent<Animator>();
        animator3 = exitButton.GetComponent<Animator>();


        StartCoroutine(animate());
    }
    public IEnumerator animate()
    {
        // yield return new WaitForSeconds(startDelay);

        animator1.SetTrigger("go");
        yield return new WaitForSeconds(startDelay);

        animator2.SetTrigger("go");
        yield return new WaitForSeconds(startDelay);

        animator3.SetTrigger("go");
        
    }
}
