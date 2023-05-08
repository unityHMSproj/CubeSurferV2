using UnityEngine;
using TMPro;


public class getData : MonoBehaviour
{
    public TextMeshProUGUI text;

    private void Start()
    {
        text.SetText((PlayerPrefs.GetInt("cheese")).ToString());
    }
}
