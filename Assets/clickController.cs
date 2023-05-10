
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class clickController : MonoBehaviour, IPointerDownHandler
{
    public List<Sprite> imageList;
    public Image imageHolder;
    private int currentimageNo;
    private int startNo = 0;
    private void Start()
    {
        currentimageNo = startNo;
        imageHolder.sprite = imageList[currentimageNo];
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        currentimageNo++;
        currentimageNo = currentimageNo % 3;
        imageHolder.sprite = imageList[currentimageNo];

        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }
}
