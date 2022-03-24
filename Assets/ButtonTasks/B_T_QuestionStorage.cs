using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_T_QuestionStorage : MonoBehaviour
{
    // Start is called before the first frame update

    // the index of each array correspond to each other, paired
    [TextArea(3,5)]
    public string[] questions;
    
    // for yes or no questions
    public string[] incorrectAnswersYesNo;
    public string[] answersManagerYesNo;

    // for the simple questions
    public string[] incorrectNames;
    public string[] correctNamesStorage;

    public string correctName;

    

    

    public GameObject simpleBtask1;

    public Transform parentCanvas;

    public float timer;

    private void Awake()
    {
        int index = Random.Range(0, 2);
        correctName = correctNamesStorage[index];
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        // RN INSTANTIATION BC SPAWNING IS NOT GONNA BE THAT INTENSIVE FOR OUR GAME RIGHT NOW
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            GameObject Btask1 = Instantiate(simpleBtask1,parentCanvas);

            // can change later, this is temporary
            Btask1.transform.localPosition = new Vector2(Random.Range(-200,200),Random.Range(-200,200));
            timer = 3;
        }


        // either instantitate or setactive from pool
    }
}
