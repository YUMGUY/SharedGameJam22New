using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rbt_Movement : MonoBehaviour
{
    // will use a waypoint system, CAN BE CHANGED TO VELOCITY SYSTEM

    public Vector3[] Waypoints;
    public int indexWaypoint;
    public bool reachedDestination;
    private Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        indexWaypoint = 0;
        reachedDestination = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(reachedDestination == false)
        {
                // the code for moving the robot automatically
            if(Vector3.Distance(transform.position, Waypoints[indexWaypoint]) <= .1f)
            {
                ++indexWaypoint;
               
                // this avoid index out of bounds error
                if(indexWaypoint >= Waypoints.Length)
                {
                    indexWaypoint = 2;
                    print("after reaching destination" + indexWaypoint);
                    reachedDestination = true;
                    
                }

                //if(indexWaypoint == 2)
                //{

                //}
                //++indexWaypoint;
                //print(indexWaypoint);
            }
            // takes 5 seconds to smoothly move form each waypoint, **** WILL BE CHANGED ***********
            transform.position = Vector3.SmoothDamp(transform.position, Waypoints[indexWaypoint], ref velocity, 5f);
        }

        if(reachedDestination == true)
        {
            print("YOU ARRIVED! VICTORY!");
        }
        

    }
       
}
