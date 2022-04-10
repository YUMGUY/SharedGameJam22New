using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carEventManager : MonoBehaviour
{

    public Rbt_Movement robotControl;
    private bool startCoFlag;
    [SerializeField]
    private GameObject phase1;

    // dealing with failure
    public bool phase1Fail = false;
    public bool phase2Fail = false;

    // Start is called before the first frame update
    private void Awake()
    {
        phase1 = GameObject.Find("Phase 1 GameObject");
    }
    void Start()
    {
        // now has access to waypoint index and canMove
        robotControl = GameObject.FindGameObjectWithTag("Player").GetComponent<Rbt_Movement>();

        // at the beginning
        phase1.SetActive(false);
        startCoFlag = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // IF AT WAYPOINT (INSERT NUMBER), WORKS AS OF NOW, JUST NEED TO CHANGE WAYPOINTS AND TIMING
        if(robotControl.indexWaypoint == 2 && startCoFlag == false)
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
            yield return null;
        }
       
        print("robot can move now");
        robotControl.canMove = true;
        yield return null;
    }
}
