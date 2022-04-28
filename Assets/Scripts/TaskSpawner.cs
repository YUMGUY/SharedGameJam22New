using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskSpawner : MonoBehaviour
{
    public GameObject[] taskListMaster;
    public GameObject[] taskListExtra; 
    public GameObject randomTask;
    public Error_TasksTracker taskManager;
    public float timer;
    public float extratimer; // for the smaller adds and such
    private float cd;
    private float standardTick;
    private int taskLen;
    public PauseAndRestart pauseState;
    public bool paused;
    public bool check; //this is a testing variable
    public Transform parentCanvas;
    public NGHealthBar health;
    //the following are all the prefab objects for the tasks//
    public GameObject buttonTask;
    public GameObject captchaTask;
    public GameObject bugTask;

    [Header("game started flag setter")]
    public Intro_Flag_Mech introPagetaskref;
    ////////////////////////////////////////////////////////////
    // Start is called before the first frame update
    private void Awake()
    {
        introPagetaskref = GameObject.Find("Introduction Page").GetComponent<Intro_Flag_Mech>();   
    }
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
        taskLen = taskListMaster.Length;
    }

    // Update is called once per frame
    void Update()
    {
        paused = pauseState.isPaused();
        standardTick += Time.deltaTime;
        if(!paused && introPagetaskref.gameStartedIntro == true) // add intro flag
        {
            
            TickDown(standardTick);
            if(timer <= 0)
            {
                randomTask = taskListMaster[(int)(Random.Range(0,taskLen))]; // From Timmy: Right now I understand that we are selecting the Button Manager, but why not have the taskListMaster array be filled
                                                // with the prefabs themselves?
                Spawn(randomTask);              // since the tasks themselves have tags, then line 61 can just check if tasktype.tag == "ButtonTask1", etc
                timer = cd;
            }
        }
        standardTick = 0;

    }
    // called to spawn a task
    void Spawn(GameObject taskType) // Overall this method is fine
    {
        
        GameObject Btask = Instantiate(taskType, parentCanvas);
        Btask.transform.localPosition = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
    }
    // decrements the time till spawn
    void TickDown(float tick)
    {
        timer -= tick;
        extratimer -= tick;
    }
}
