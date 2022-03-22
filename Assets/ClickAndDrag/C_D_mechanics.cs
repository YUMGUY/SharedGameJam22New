using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class C_D_mechanics : MonoBehaviour/*, IPointerDownHandler, IPointerUpHandler */
{
    public GameObject clickanddrag;

   // private RectTransform destination;
    private bool isSelected = false;
    public bool isCompleted = false;

    // can change later on
    private float[] randomPositionsDestinationX = { 100, 200, 250, 280 };
    private float[] randomPositionsDestinationY = { 100, 200, 250, 280 };
    private float[] randomPositionsStartX = { 100, 200,210 ,220 };
    private float[] randomPositionsStartY = { 100, 200, 210, 220 };
    // variables of position and whether mouse is clicked on the object

    // Start is called before the first frame update


    // provides random location of the task
    private void Awake()
    {
        clickanddrag = this.transform.GetChild(0).gameObject;
        int indexPosition = Random.Range(0, 3);
     
        clickanddrag.transform.localPosition = new Vector2(randomPositionsStartX[indexPosition],randomPositionsStartY[indexPosition]);
       // destination = this.GetComponent<RectTransform>();

        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomPositionsDestinationX[indexPosition], randomPositionsDestinationY[indexPosition]);
        // this is just a test version, will make it more complex next time
       // this.transform.position = new Vector3(randomPositionsDestinationX[indexPosition], randomPositionsDestinationY[indexPosition]);
       
    }
    void Start()
    {

       print( this.GetComponent<RectTransform>().anchoredPosition);
     
    }

    // Update is called once per frame
    void Update()
    {

        // scuffed way but it works?

          isCompleted = clickanddrag.GetComponent<DragChild_Memory>().isCompleted2;

          if(isSelected == true)
            {   
            
                clickanddrag.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }

      
          // 
          if(isCompleted == true)
            {
                print("yay completed task");
                this.gameObject.SetActive(false);
            }
       
    }
   
    // change this to be in the child script
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log(name + " was clicked");

    //    isSelected = true;
        
    //}

    //public void OnPointerUp(PointerEventData eventData)
    //{   
    //    // the margin of error allowed for completing the task
    //    isSelected = false;
    //    print(positionDestination.localPosition);
    //    if(Mathf.Abs(positionDestination.localPosition.x) <= 12f && Mathf.Abs(positionDestination.localPosition.y) <= 12f)
    //    {
    //        isCompleted = true;
    //    }


    //}
}
