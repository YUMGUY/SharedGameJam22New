using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempRotate : MonoBehaviour
{

    private float rotZ;
    public float temp;
    public float heat;
    public float rotSpeed;
    public Error_TasksTracker track;

    public RectTransform transformTemp;
    


    // Start is called before the first frame update
    public void Start()
    {
       
        rotZ = 90;
        heat = 100;
        transformTemp.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    // Update is called once per frame
    public void Update()
    {
        //print(rotZ);
        //rotZ += -Time.deltaTime * rotSpeed;
        temp = track.getTaskCount();
        if(rotZ >= 0  && rotZ <= 91)
        {
           // print("this is working");
            if(temp == 0 && rotZ < 90) // I change it so that it rotates properly, we can change the conditions
            {
                rotZ += Time.deltaTime * rotSpeed;
            }
            else
            {
             //   print("decreasing -90");
                rotZ += -Time.deltaTime * rotSpeed;
                heat = 100 - temp * (50 *  (1 - rotZ / 90)); // with regards to heat, more tasks show up?
            }
            
        }
        else
        {
         //   print("this is not working");
            if(rotZ < 0 && rotZ > -90) // change the conditions of this?
            {
                if(temp == 0) // change the conditions of this? add onto it
                {
                    rotZ += Time.deltaTime * rotSpeed;
                }
                else
                {
                    rotZ += -Time.deltaTime * rotSpeed;
                    heat = 50 - temp * (50 * (rotZ / 90));
                }
            
                
            }
        }
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }

}
