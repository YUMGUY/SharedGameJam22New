using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rbt_Movement : MonoBehaviour
{
    // will use a waypoint system, CAN BE CHANGED TO VELOCITY SYSTEM
    
    public Vector3[] Waypoints;
    public int indexWaypoint;
    public bool reachedDestination;
    public bool canMove = false;
    private Vector3 velocity = Vector3.zero;

    int timeIndex;

    // the angles or turns that the robot will make during his automatic journey
    // will mae a Quaternion[] turn array later on
    public Quaternion turn1 = Quaternion.Euler(0, 90, 0);

    public Quaternion turn2 = Quaternion.Euler(0, 0, 0);

    public Quaternion turn3 = Quaternion.Euler(0, -90, 0);
    public bool turn2Started = false;

    private bool turn1Started = false;

    // making a parallel array of times for each point of the journey
    [Header("Time between Waypoints")]
    public float[] times;

    // will change in according to the active state of the introductory page
    [Header("The Game State")]
    public bool gameStarted;

    [Header("Taken Car Damage")]
    public bool takenCarDamage;
    public NGHealthBar hpRefRobot;


    [Header("Victory Pan")]
    public bool willPan;

    [Header("Camera Animation Handler")]
    public Animator childCamera;

    [Header("game start flag")]
    public Intro_Flag_Mech introPg;

    private void Awake()
    {
        introPg = GameObject.Find("Introduction Page").GetComponent<Intro_Flag_Mech>() ;
    }

    // Start is called before the first frame update
    void Start()
    {
        // to be able to set the bool victorySet
        hpRefRobot = GameObject.Find("HealthBar").GetComponent<NGHealthBar>();
        childCamera = GetComponentInChildren<Animator>();


        gameStarted = false;
        takenCarDamage = false;
        indexWaypoint = 0;
        timeIndex = 0;

        reachedDestination = false;
        canMove = true;
        //StartCoroutine(RotationToAngle(turn1)); // for testing turns

        // the camera movement at the victory end
        willPan = false;
        turn1Started = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (reachedDestination == false && canMove == true && introPg.gameStartedIntro == true)
        {
            // the code for moving the robot automatically
            if (Vector3.Distance(transform.position, Waypoints[indexWaypoint]) <= .1f)
            {
               // print("index changed");
                ++indexWaypoint;
                ++timeIndex;

                if(indexWaypoint == 1 && turn1Started == false)
                {
                    StartCoroutine(RotationToAngle(turn1));
                }

                if(indexWaypoint == 3 && !turn2Started)
                {
                   
                    StartCoroutine(RotationToAngle(turn2));
                    turn2Started = true;
                }
                //    this avoid index out of bounds error
                if (indexWaypoint >= Waypoints.Length)
                {
                    indexWaypoint = 8; // have to hard code the index waypoint
                    timeIndex = times.Length - 1;
                    print("finished after reaching destination " + indexWaypoint);
                    reachedDestination = true;

                }


            }
            //   will take approximately 3 seconds, may take even longer, **** WILL BE CHANGED ***********
            transform.position = Vector3.SmoothDamp(transform.position, Waypoints[indexWaypoint], ref velocity, times[timeIndex]);
        }

        // this is for when the robot reaches the destination, panning around the robot
        willPan = GetComponentInChildren<VictoryPan>().canPan;
        if(willPan == true)
        {
            this.transform.Rotate(0, 5 * Time.deltaTime, 0);
        }

        if(reachedDestination == true)
        {
            childCamera.SetBool("victorySet", true);
        }
    }




    /////////////////////////////////////////////////////////////////////// Code For Rotating to A Certain Angle /////////////////////////////////////////////////////////////////////////////

    // smooth rotation
    private IEnumerator RotationToAngle(Quaternion targetRotation)
    {
        // this is to disable the movement of the robot
        yield return new WaitForSeconds(.1f);
        canMove = false;


        float elapsedTime = 0f;

        Quaternion startingRotation = transform.rotation;
        while (elapsedTime < 2f)
        {

            elapsedTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, Mathf.SmoothStep(0,1,(elapsedTime/2f)));
            yield return new WaitForEndOfFrame();
        }
        
        // this is to enable the robot to move again
       // print("done");
        canMove = true;

      
    }


    // FOR CAR COLLISION, WORKS

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("car"))
        {
            other.GetComponent<Rigidbody>().AddExplosionForce(1000f, new Vector3(-1, -1f, -1f), 15f, 3f);
            other.GetComponent<carMovement>().exploded = true;
            print("you pushed it");

            // when robot collides with car, take damage once, set takenCarDamage = true
            if(takenCarDamage == false)
            {
                // do something to battery;
                hpRefRobot.hp -= 20f;
                takenCarDamage = true;
            }
        }
    }

}
