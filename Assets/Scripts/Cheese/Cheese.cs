using UnityEngine;

public class Cheese : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360f * 0.5f * Time.deltaTime);
    }
    public void collectCheese()
    {
        PlayerPrefs.SetInt("cheese", PlayerPrefs.GetInt("cheese") + 1);
    }
}
