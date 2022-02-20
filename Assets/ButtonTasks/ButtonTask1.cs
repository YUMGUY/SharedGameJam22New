using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonTask1 : MonoBehaviour
{
    // input from the player from the 2 buttons: 0 is for right, 1 is for left
    private int playerInput = -1;

    // this is so that we can easily set the question's answer to either 0 or 1
    //int[] copylist = new int[3] { 5, 0, 0 };
    //private int[] answerList = new int[3] { 0, 1, 0 };
    public int answerRequired = 0; // this will change depending on the index of the answerList

    // reference to the parent

    // references to the 2 children ( left and right button )
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject textBoxQuestion;
    public TextMeshProUGUI questionContent;

    /* Changing the text of the buttons in order to fit the prompt
     */

    int indexOfQuestionArray;

    // this might change to just making an array of strings in here instead of calling upon another class
    public B_T_QuestionStorage buttonManagerScript;


    private void OnEnable()
    {
        // rn only have 3 questions in storage
        indexOfQuestionArray = Random.Range(0, 3);
        textBoxQuestion.GetComponent<TextMeshProUGUI>().text = buttonManagerScript.questions[indexOfQuestionArray];
        answerRequired = buttonManagerScript.answersManager[indexOfQuestionArray];
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
       // copylist.CopyTo(answerList, 0);
        //answerRequired = answerList[0];
       // print(answerRequired);

        

        
        print(textBoxQuestion.name);

        // this is temporary
       
    }

    // Update is called once per frame
    void Update()
    {

        if(playerInput == answerRequired)
        {
            print("you chose the right answer");
            this.gameObject.SetActive(false);
        }
    }

    // maybe can just add a generic 
    public void OnClickLeft()
    {
        playerInput = 1;
        print("you chose the answer on the left: 1");
    }

    public void OnClickRight()
    {
        playerInput = 0;
        print("you chose the answer on the right : 0");
    }
}
