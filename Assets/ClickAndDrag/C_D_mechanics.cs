using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class C_D_mechanics : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject clickanddrag;
    RectTransform positionDestination;
    private bool isSelected = false;
    public bool isCompleted = false;
    // variables of position and whether mouse is clicked on the object

    // Start is called before the first frame update
    void Start()
    {
        
        positionDestination = clickanddrag.GetComponent<RectTransform>();
        print(positionDestination.anchoredPosition3D);
    }

    // Update is called once per frame
    void Update()
    {
      if(isSelected == true)
        {
            clickanddrag.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

      if(isCompleted == true)
        {
            print("yay");
        }
       
    }
   

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("it was clicked");
        
        isSelected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isSelected = false;
        print(positionDestination.localPosition);
        if(Mathf.Abs(positionDestination.localPosition.x) <= 10f && Mathf.Abs(positionDestination.localPosition.y) <= 10f)
        {
            isCompleted = true;
        }


    }
}
