using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class BugTask : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool completedTask;
    public int numberOfActiveChildren;
    public int sum;

    private bool isSelectedBug;

    // allows for good dragging
    private float startPosY;
    private float startPosX;

    // change color to white
    public TextMeshProUGUI titleText;

    // for bugs
    public GameObject bug;
    private Vector2[] velocities =
       {new Vector2(100,10),
        new Vector2(50, 80),
        new Vector2(-10, -120),
        new Vector2(-100, -60),
        new Vector2(-200,10),
        new Vector2(-200,50),
        new Vector2(90,-90)};

    int[] array = new int[7];
        
    private void Awake()
    {
        titleText = this.transform.GetComponentInChildren<TextMeshProUGUI>();
        titleText.color = Color.white;

        HashSet<int> h = new HashSet<int>();
        while(h.Count < 7)
        {
            h.Add(Random.Range(0, 7));
        }

        
        h.CopyTo(array); // now array is filled with random, unique numbers
  
        // creating the bugs

            
        
       
    }
    private void OnEnable()
    {
        // if battery level is low or malfunction state is true, create 10
        for (int i = 0; i < 5; ++i)
        {
            int index = array[i];
            GameObject childBug = Instantiate(bug, this.transform);
            childBug.GetComponent<Rigidbody2D>().velocity = velocities[index];
        }
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
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX,mousePos.y - startPosY);
        }

        if (completedTask == true)
        {
            gameObject.SetActive(false);
        }

    }

    // dealing with dragging
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
