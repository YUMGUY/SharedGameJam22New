using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragChild_Memory : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
   // public GameObject clickanddrag;
   // RectTransform positionDestination2;
    private bool isSelected2 = false;
    public bool isCompleted2 = false;


    private float[] randomPositionsDestinationX = { 100, 200, 300, 400 };
    private float[] randomPositionsDestinationY = { 100, 200, 300, 400 };
    private float[] randomPositionsStartX = { 100, 200, 300, 400 };
    private float[] randomPositionsStartY = { 100, 200, 300, 400 };
    // Start is called before the first frame update
    void Start()
    {
       // positionDestination2 = this.transform.parent.gameObject.GetComponent<RectTransform>();
        //print(positionDestination2);
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected2 == true)
        {
            this.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(name + " was clicked");

        isSelected2 = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // the margin of error allowed for completing the task
        isSelected2 = false;
        print(this.transform.localPosition);
        if (Mathf.Abs(this.transform.localPosition.x) <= 12f && Mathf.Abs(this.transform.localPosition.y) <= 12f)
        {
            isCompleted2 = true;
        }


    }
}
