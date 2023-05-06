using UnityEngine;
using TMPro;


public class getData : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        // PlayerPrefs.SetInt("cheese", 0);
    }
    private void Update()
    {
        text.SetText((PlayerPrefs.GetInt("cheese")).ToString());
    }
}
