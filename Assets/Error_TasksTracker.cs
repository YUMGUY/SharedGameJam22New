using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error_TasksTracker : MonoBehaviour
{

    int numberofTasks = 0;
    int memoryCount;
    int buttonTask1Count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        memoryCount = GameObject.FindGameObjectsWithTag("MemoryBlock").Length;
        buttonTask1Count = GameObject.FindGameObjectsWithTag("ButtonTask1").Length;
        
        numberofTasks = memoryCount + buttonTask1Count;

        print("the number of tasks is" + numberofTasks);


        // then add conditions when numberofTasks is above a certain number/threshold

        if(numberofTasks > 5)
        {
            print("bruh");
        }


    }
}
