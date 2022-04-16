using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase2Mechanics : MonoBehaviour
{
    

    // FOR PHASE 2
    public carEventManager carEventOrigin2;

    public int completedArrow;
    public int missedArrow;
    
    // Start is called before the first frame update
    void Start()
    {
        // uncomment when finished with car event manager
        carEventOrigin2 = GameObject.Find("Car Event Manager").GetComponent<carEventManager>();
        completedArrow = 0;
        missedArrow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if number of missed arrows >= 2, then FAILED PHASE 2
        if(missedArrow >= 2 && completedArrow >= 4)
        {
           // print("you failed phase 2 you bozo");
            carEventOrigin2.phase2Fail = true;
            StartCoroutine(Failure2());
        }

        else if(missedArrow < 2 && completedArrow >= 4)
        {
            print("yay you did it");
            this.gameObject.SetActive(false);
        }
    }

    public void MissedArrow()
    {
        print("missed arrow");
        ++missedArrow;
        ++completedArrow;
    }

    public void HitArrow()
    {
        print("success");
        ++completedArrow;
    }

    public IEnumerator Failure2()
    {
        yield return new WaitForSeconds(.1f);
        this.gameObject.SetActive(false);
    }
}
