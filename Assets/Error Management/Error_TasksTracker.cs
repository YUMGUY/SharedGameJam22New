using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error_TasksTracker : MonoBehaviour
{

    public int numberofTasks = 0;
    // count of all the tasks in the scene that are active
    [Header("Count of All Types of Tasks")]
    public int memoryCount;
    public int buttonTask1Count;
    public int bugtaskCount;
    public int wifiPWtaskCount;
    public int captchaCount;
    public int recycleBinCount;
    public int adCount;

    // make error window count visible
    [SerializeField]
    private int numberOfErrors = 0;
    // this is a flag for stopping everything when destination is reached
    public Rbt_Movement gameFlag;
    public bool gameFinished;
    // Start is called before the first frame update

    // handing the SPAWNING OF tasks
    [Header("Types of Tasks To Spawn")]
    [SerializeField]
    public GameObject[] taskTypes;           // ERRORS COUNT AS TASKS TOO /////
   
    void Start()
    {
        gameFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        // a flag to determine whether or not to spawn the tasks in the future when the end screen comes up
        gameFinished = gameFlag.reachedDestination;
        

        
        memoryCount = GameObject.FindGameObjectsWithTag("MemoryBlock").Length;
        buttonTask1Count = GameObject.FindGameObjectsWithTag("ButtonTask1").Length;
        bugtaskCount = GameObject.FindGameObjectsWithTag("BugTask").Length;
        numberOfErrors = GameObject.FindGameObjectsWithTag("error").Length;
        wifiPWtaskCount = GameObject.FindGameObjectsWithTag("wifi").Length;
        captchaCount = GameObject.FindGameObjectsWithTag("captcha").Length;
        recycleBinCount = GameObject.FindGameObjectsWithTag("recycle").Length;
        adCount = GameObject.FindGameObjectsWithTag("ads").Length;
        numberofTasks = memoryCount + buttonTask1Count + bugtaskCount + wifiPWtaskCount + captchaCount + recycleBinCount + adCount + numberOfErrors;

       // print("the number of tasks is" + numberofTasks);


        // then add conditions when numberofTasks is above a certain number/threshold



    }

    public int getTaskCount()
    {
        return numberofTasks;
    }

    //public IEnumerator testCo()
    //{
    //    print("this is a testCoroutine");
    //    yield return null;
    //}

}
