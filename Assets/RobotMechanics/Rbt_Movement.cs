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

    // the angles or turns that the robot will make during his automatic journey
    // will mae a Quaternion[] turn array later on
    public Quaternion turn1 = Quaternion.Euler(0, 30, 0);
    public Quaternion turn2 = Quaternion.Euler(0, 120, 0);
    public Quaternion turn3 = Quaternion.Euler(0, 80, 0);
    public bool turn2Started = false;


    // making a parallel array of times for each point of the journey
    public float[] times;


    // Start is called before the first frame update
    void Start()
    {
        indexWaypoint = 0;
        reachedDestination = false;
        canMove = true;
        StartCoroutine(RotationToAngle(turn1));
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (reachedDestination == false && canMove == true)
        {
            // the code for moving the robot automatically
            if (Vector3.Distance(transform.position, Waypoints[indexWaypoint]) <= .1f)
            {
                ++indexWaypoint;
                if(indexWaypoint == 2 && !turn2Started)
                {
                    StartCoroutine(RotationToAngle(turn3));
                    turn2Started = true;
                }
                //    this avoid index out of bounds error
                if (indexWaypoint >= Waypoints.Length)
                {
                    indexWaypoint = 2;
                    print("finished after reaching destination" + indexWaypoint);
                    reachedDestination = true;

                }


            }
            //     takes 3 seconds to smoothly move from each waypoint, **** WILL BE CHANGED ***********
            transform.position = Vector3.SmoothDamp(transform.position, Waypoints[indexWaypoint], ref velocity, 3f);
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

}
