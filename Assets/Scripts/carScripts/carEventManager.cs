using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEventManager : MonoBehaviour
{

    public Rbt_Movement robotControl;
    private bool startCoFlag;

    [Header("Phase Flags")]
    [SerializeField]
    private GameObject phase1;
    [SerializeField]
    private GameObject phase2;

    // dealing with failure
    public bool phase1Fail = false;
    public bool phase2Fail = false;

    // Start is called before the first frame update
    private void Awake()
    {
        phase1 = GameObject.Find("Phase 1 GameObject");
        phase2 = GameObject.Find("Phase 2 GameObject");
    }
    void Start()
    {
        // now has access to waypoint index and canMove
        robotControl = GameObject.FindGameObjectWithTag("Player").GetComponent<Rbt_Movement>();

        // at the beginning
        phase1.SetActive(false);
        phase2.SetActive(false);

        startCoFlag = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // IF AT WAYPOINT (INSERT NUMBER), WORKS AS OF NOW, JUST NEED TO CHANGE WAYPOINTS AND TIMING ( current way point is 5 )
        if(robotControl.indexWaypoint == 6 && startCoFlag == false)
        {
            StartCoroutine(carEvent());
            startCoFlag = true;
        }


        
    }

    public IEnumerator carEvent()
    {
        phase1.SetActive(true);
        robotControl.canMove = false;

        // FOR TESTING
        while(phase1.activeInHierarchy == true)
        {
            // if phase1 fail == true, set robotcontrol.canMove = true, yield break
            if(phase1Fail == true)
            {
                print("you failed PHASE 1");   // make gameobject text that flashes ( setactive )
                robotControl.canMove = true;
                // stops the coroutine
                yield break;
            }
            yield return null;
        }
        print("PHASE 1 FINISHED");
        phase2.SetActive(true);

        // then do phase 2, TESTING
        while(phase2.activeInHierarchy == true)
        {
            // IF PHASE 2 FAIL == TRUE, set robotcontrol.canMove = true, yield break
            if(phase2Fail == true)
            {
                print("you failed PHASE 2, prepare for damage");  // make gameobject text that flashes ( setactive )
                robotControl.canMove = true;
                yield break;
            }

            yield return null;
        }

        print("PHASE 2 HAS FINISHED, HURRAY, now wait 10 seconds");


     
        // maybe do a waiting period before the robot can move, so that FOR SURE cars are out of the way
        yield return new WaitForSeconds(10f);
        print("robot can move now");
        robotControl.canMove = true;
        yield return null;
    }

    // TO PUNISH THE PLAYER, lose 35% battery
}
