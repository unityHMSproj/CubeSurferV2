using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveScore : MonoBehaviour
{
    
    public TextMeshProUGUI scoreText;

    private void Start() {
        
    }

    private void Update() {
        scoreText.SetText((PlayerPrefs.GetInt("cheese").ToString()));
    }

}
