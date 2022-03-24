using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonTask1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // dragging the windows

    // allows for good dragging
    private float startPosY2;
    private float startPosX2;
    private bool isSelect;

    // input from the player from the 2 buttons: 0 is for right, 1 is for left
    private int playerInput = -1;

    // this is so that we can easily set the question's answer to either 0 or 1
   
    public int answerRequired = 0; // this will change depending on the index of the answerList

    // reference to the parent

    // references to the 2 children ( left and right button )
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject textBoxQuestion;
    public TextMeshProUGUI questionContent;


    // will be changed later/ IMPROVED
    public TextMeshProUGUI leftButtonText;
    public TextMeshProUGUI rightButtonText;

    public bool playerAnswered = false;

    /* Changing the text of the buttons in order to fit the prompt
     */

    int indexOfQuestionArray;

    // this might change to just making an array of strings in here instead of calling upon another class
    public B_T_QuestionStorage buttonManagerScript;


    private void OnEnable()
    {
        // rn only have 3 questions in storage
        indexOfQuestionArray = Random.Range(0, 3);
        textBoxQuestion.GetComponent<TextMeshProUGUI>().color = Color.black;
        textBoxQuestion.GetComponent<TextMeshProUGUI>().text = buttonManagerScript.questions[indexOfQuestionArray];
        answerRequired = buttonManagerScript.answersManager[indexOfQuestionArray];
        playerAnswered = false;
    }

    private void OnDisable()
    {
       // indexOfQuestionArray = Random.Range(0, 2);
       // textBoxQuestion.GetComponent<TextMeshProUGUI>().text = buttonManagerScript.questions[indexOfQuestionArray];
        // reset so that we can answer multiple
        playerInput = -1;
      
    }
    private void Awake()
    {
        textBoxQuestion = this.transform.GetChild(2).gameObject;
        buttonManagerScript = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<B_T_QuestionStorage>();
    }

    // Start is called before the first frame update
    void Start()
    {
   
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // deals with selecting it
        if (isSelect == true)
        {

            Vector3 mousePos = Input.mousePosition;
            //mousePos = Camera.main.ScreenToViewportPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX2, mousePos.y - startPosY2);
        }

        // dealing with the completion of the task, might just do destroy
        if (playerInput == answerRequired && playerAnswered == true)
        {
            print("you chose the right answer");
            this.gameObject.SetActive(false);
        }

        else if(playerAnswered == true && playerInput != answerRequired)
        {
            // add a punishment
            print("you chose the wrong answer loser");
            this.gameObject.SetActive(false);
        }

        
    }

    // maybe can just add a generic 
    public void OnClickLeft()
    {
        playerInput = 1;
        playerAnswered = true;
        //print("you chose the answer on the left: 1");
    }

    public void OnClickRight()
    {
        playerInput = 0;
        playerAnswered = true;
        //print("you chose the answer on the right : 0");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 mousePos1 = Input.mousePosition;
        //mousePos1 = Camera.main.ScreenToViewportPoint(mousePos1);
        startPosX2 = mousePos1.x - this.transform.localPosition.x;
        startPosY2 = mousePos1.y - this.transform.localPosition.y;

        isSelect = true;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // the margin of error allowed for completing the task
        isSelect = false;


    }
}
