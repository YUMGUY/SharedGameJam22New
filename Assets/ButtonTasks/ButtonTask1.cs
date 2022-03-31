using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonTask1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    // dragging the windows

    // allows for good dragging
    private float startPosY2;
    private float startPosX2;
    private bool isSelect;

    // change the color of the task based on whether it is correct or not
    // 98,255,124,255
    private Color32 green = new Color32(98, 255, 124, 255);

    private Color32 red = new Color32(255, 90, 90, 255);
    private Image window;

    // input from the player from the 2 buttons: 0 is for right, 1 is for left
   // private int playerInput = -1;

    private string playerInputString = "";
    // this is so that we can easily set the question's answer to either 0 or 1

    public int answerRequired = 0; // this will change depending on the index of the answerList
    private string correctNameTask;
    private string correctAnswerString;
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
    private bool flag1 = false;
    private bool correct;

    /* Changing the text of the buttons in order to fit the prompt
     */

    int indexOfQuestionArray;

    // this might change to just making an array of strings in here instead of calling upon another class
    public B_T_QuestionStorage buttonManagerScript;

    // OVERALL THIS IS HARDCODED SO THIS IS REALLY TEDIOUS.
    private void OnEnable()
    {   
        window = this.GetComponent<Image>();
        playerInputString = "";
        // rn only have 3 questions in storage
        indexOfQuestionArray = Random.Range(0, 3);
        textBoxQuestion.GetComponent<TextMeshProUGUI>().color = Color.black;
        textBoxQuestion.GetComponent<TextMeshProUGUI>().text = buttonManagerScript.questions[indexOfQuestionArray];

        correctNameTask = buttonManagerScript.correctName;
        window.color = Color.white;


        // change the text of the left and right buttons, choose which box will have the incorrect answer
        // BELOW IS YES OR NO QUESTIONS
        int chooseBox = Random.Range(0, 2);
        if (indexOfQuestionArray == 0 || indexOfQuestionArray == 1)
        {
            if (chooseBox == 0)
            {
                leftButtonText.text = buttonManagerScript.incorrectAnswersYesNo[indexOfQuestionArray];
                rightButtonText.text = buttonManagerScript.answersManagerYesNo[indexOfQuestionArray];
                correctAnswerString = buttonManagerScript.answersManagerYesNo[indexOfQuestionArray];  // this allows for no error and correct match of answer, 0 or 1
            }

            else
            {
                rightButtonText.text = buttonManagerScript.incorrectAnswersYesNo[indexOfQuestionArray];
                leftButtonText.text = buttonManagerScript.answersManagerYesNo[indexOfQuestionArray];
                correctAnswerString = buttonManagerScript.answersManagerYesNo[indexOfQuestionArray];
            }
        }

        // for different types of questions
        if (indexOfQuestionArray == 2) // THE NAME QUESTION
        {

            if (chooseBox == 0)
            {
                // right now only have 2 incorrect names
                int randomName = Random.Range(0, 2);
                leftButtonText.text = buttonManagerScript.incorrectNames[randomName];
                rightButtonText.text = correctNameTask;
            }

            else
            {
                int randomName = Random.Range(0, 2);
                rightButtonText.text = buttonManagerScript.incorrectNames[randomName];
                leftButtonText.text = correctNameTask;
            }
        }

        // basically hard code in questions


        playerAnswered = false;
    }

    private void OnDisable()
    {

        // reset so that we can answer multiple
        //playerInput = -1;
        playerInputString = "";
        flag1 = false;
        correct = false;

    }
    private void Awake()
    {
        textBoxQuestion = this.transform.GetChild(2).gameObject;
        buttonManagerScript = GameObject.FindGameObjectWithTag("ButtonManager").GetComponent<B_T_QuestionStorage>();


        // reference for the text boxes of the buttons
        leftButton = this.transform.GetChild(0).gameObject;
        rightButton = this.transform.GetChild(1).gameObject;

        leftButtonText = leftButton.GetComponentInChildren<TextMeshProUGUI>();
        rightButtonText = rightButton.GetComponentInChildren<TextMeshProUGUI>();


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
      

        if ((playerInputString == correctNameTask || playerInputString == correctAnswerString) && playerAnswered == true && flag1 == true)
        {
            print("megu megu fire endless night");
            correct = true;
            StartCoroutine(changeColor());
            flag1 = false;
            //this.gameObject.SetActive(false);
            
        }

        else if( (playerInputString != correctAnswerString && playerInputString != correctNameTask) && playerAnswered == true && flag1 == true)
        {
            print("wrong");
            correct = false;
            StartCoroutine(changeColor());
            flag1 = false;
           // this.gameObject.SetActive(false);
        }
        
        

        
    }
    private IEnumerator changeColor()
    {
        float elapsedTime = 0f;
        float totalTime = .15f;
        while(elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            if(correct == true)
            {
                window.color = Color.Lerp(Color.white, green, elapsedTime / totalTime);
            }

            else
            {
                window.color = Color.Lerp(Color.white, red, elapsedTime / totalTime);
            }
            
            yield return null;
        }


        this.gameObject.SetActive(false);
    }
    // maybe can just add a generic 
    public void OnClickLeft()
    {
        //playerInput = 1;
        playerAnswered = true;
        flag1 = true;
        playerInputString = leftButtonText.text;
    }

    public void OnClickRight()
    {
        //playerInput = 0;
        playerAnswered = true;
        flag1 = true;
        playerInputString = rightButtonText.text;
       
    }


    // for dragging
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
