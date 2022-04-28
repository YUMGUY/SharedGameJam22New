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

    [Header("Enabling Screen Glitches")]
    public GameObject screen1Whole;
    public GameObject screen2Whole;
    public Animator screen1;
    public Animator screen2;
    public NGHealthBar hpBarReference;
    [SerializeField]
    private float bufferTime;
    public float timerGlitch1CoolD;
    public float timerGlitch1;
    public bool stopGlitch1;

    [Header("Timer for 2nd Glitch")]
    public float timerGlitch2CoolD;
    public float timerGlitch2;

    void Start()
    {
        screen1 = screen1Whole.GetComponent<Animator>();
        screen2 = screen2Whole.GetComponent<Animator>();
        hpBarReference = GameObject.Find("HealthBar").GetComponent<NGHealthBar>();
        gameFinished = false;
        bufferTime = 5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        // a flag to determine whether or not to spawn the tasks in the future when the end screen comes up
        
        // activate 2nd screen
        if(hpBarReference.hp <= 60)
        {
            // switch screens
            screen1Whole.SetActive(false);
            screen2Whole.SetActive(true);
        }

        // give a 5 second buffer so that the screen doesnt glitch for 5 seconds
        if (stopGlitch1 == true && screen1Whole.activeInHierarchy == true)
        {
            bufferTime -= Time.deltaTime;
            print("buffer");
            if(bufferTime <= 0)
            {
                stopGlitch1 = false;
                bufferTime = 5;
            }
        }

        gameFinished = gameFlag.reachedDestination;
        if(hpBarReference.hp <= 80 && stopGlitch1 == false && screen1Whole.activeInHierarchy == true)
        {
            timerGlitch1 -= Time.deltaTime;
            if(timerGlitch1 <= 0)
            {
                screen1.SetTrigger("stopGlitch1");
                screen1.SetBool("willGlitch", false);
                stopGlitch1 = true;
                timerGlitch1 = timerGlitch1CoolD;
            }

            else
            {
                screen1.SetBool("willGlitch", true);
            }
            
          //  screen1Glitch();
        }

        else if(hpBarReference.hp <= 60 && screen2Whole.activeInHierarchy == true)
        {
            screen2.SetBool("willGlitchBig", true);
        }

        
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

    public void screen1GlitchReset()
    {
        print("set state 1");
        screen1.SetTrigger("stopGlitch1");
        stopGlitch1 = false;
    }
}
