using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool selectedObj;
    private float startPosXObj;
    private float startPosYObj;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObj == true)
        {
            Vector3 mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosXObj, mousePos.y - startPosYObj);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 mousePos1 = Input.mousePosition;
        //mousePos1 = Camera.main.ScreenToViewportPoint(mousePos1);
        startPosXObj = mousePos1.x - this.transform.localPosition.x;
        startPosYObj = mousePos1.y - this.transform.localPosition.y;
        selectedObj = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selectedObj = false;

    }
}
