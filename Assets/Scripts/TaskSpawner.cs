using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    public GameObject[] taskListMaster;
    //public GameObject[] taskListActive;  <--if implemented will be an active list of tasks we have active
    public GameObject randomTask;
    public Error_TasksTracker taskManager;
    public float timer;
    private float cd;
    private float standardTick;
    public PauseAndRestart pauseState;
    public bool paused;
    public bool check; //this is a testing variable
    public Transform parentCanvas;
    //the following are all the prefab objects for the tasks//
    public GameObject buttonTask;



    ////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        //if(taskManager.numberofTasks > 0)
        //{

        //}
        //GameObject[] taskListMaster = { };
        cd = timer;
        paused = false;
        standardTick = 0;
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        paused = pauseState.isPaused();
        standardTick += Time.deltaTime;
        if(!paused)
        {
            
            TickDown(standardTick);
            if(timer <= 0)
            {
                randomTask = taskListMaster[0];
                Spawn(randomTask);
                timer = cd;
            }
        }
        standardTick = 0;

    }
    // called to spawn a task
    void Spawn(GameObject taskType)
    {
        if(taskType.tag == "ButtonManager")
        {
            GameObject Btask = Instantiate(buttonTask, parentCanvas);
            Btask.transform.localPosition = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
        }
    }
    // decrements the time till spawn
    void TickDown(float tick)
    {
        timer -= tick;
    }
}
