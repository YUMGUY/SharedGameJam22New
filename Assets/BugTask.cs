using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BugTask : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool completedTask;
    public int numberOfActiveChildren;
    public int sum;

    private bool isSelectedBug;


    private float startPosY;
    private float startPosX;
    private void OnEnable()
    {
        completedTask = false;
        sum = this.transform.childCount;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
       sum = this.transform.childCount;
       for(int i = 0; i < this.transform.childCount; ++i)
        {
             
            if(this.transform.GetChild(i).gameObject.activeInHierarchy != true)
            {
                sum -= 1;
            }
        }

        numberOfActiveChildren = sum;
       // the chip is remaining only
        if (numberOfActiveChildren == 2)
        {
            print("this bug task is completed");
            completedTask = true;
        }

        // the movement of the task window 
        if(isSelectedBug == true)
        {

            Vector3 mousePos = Input.mousePosition;
            //mousePos = Camera.main.ScreenToViewportPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX,mousePos.y - startPosY);
        }

        if (completedTask == true)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 mousePos1 = Input.mousePosition;
        //mousePos1 = Camera.main.ScreenToViewportPoint(mousePos1);
        startPosX = mousePos1.x - this.transform.localPosition.x;
        startPosY = mousePos1.y - this.transform.localPosition.y;

        isSelectedBug = true;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // the margin of error allowed for completing the task
        isSelectedBug = false;


    }
}
