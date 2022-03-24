using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTask : MonoBehaviour
{
    // Start is called before the first frame update
    private bool completedTask;
    public int numberOfActiveChildren;
    public int sum;
    private void OnEnable()
    {
        completedTask = false;
        sum = this.transform.childCount;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        sum = this.transform.childCount;
       for(int i = 0; i < this.transform.childCount; ++i)
        {
             
            if(this.transform.GetChild(i).gameObject.activeInHierarchy != true)
            {
                sum -= 1;
            }
        }

        numberOfActiveChildren = sum;
       // the chip is remaining only
        if (numberOfActiveChildren == 2)
        {
            print("this bug task is completed");
            completedTask = true;
        }

        if (completedTask == true)
        {
            gameObject.SetActive(false);
        }
    }
}
