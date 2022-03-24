using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error_TasksTracker : MonoBehaviour
{

    int numberofTasks = 0;
    int memoryCount;
    int buttonTask1Count;
    int bugtaskCount;

    // this is a flag for stopping everything when destination is reached
    public Rbt_Movement gameFlag;
    public bool gameFinished;
    // Start is called before the first frame update

   
    void Start()
    {
        gameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameFinished = gameFlag.reachedDestination;
        

        
        memoryCount = GameObject.FindGameObjectsWithTag("MemoryBlock").Length;
        buttonTask1Count = GameObject.FindGameObjectsWithTag("ButtonTask1").Length;
        bugtaskCount = GameObject.FindGameObjectsWithTag("BugTask").Length;

        numberofTasks = memoryCount + buttonTask1Count + bugtaskCount;

       // print("the number of tasks is" + numberofTasks);


        // then add conditions when numberofTasks is above a certain number/threshold



    }
}
