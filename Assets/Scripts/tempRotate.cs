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

    public RectTransform transform;
    


    // Start is called before the first frame update
    public void Start()
    {
        rotZ = 90;
        heat = 100;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }

    // Update is called once per frame
    public void Update()
    {
        //rotZ += -Time.deltaTime * rotSpeed;
        temp = track.getTaskCount();
        if(rotZ >= 0  && rotZ <= 91)
        {
            if(temp == 0)
            {
                rotZ += Time.deltaTime * rotSpeed;
            }
            else
            {
                rotZ += -Time.deltaTime * rotSpeed;
                heat = 100 - temp * (50 *  (1 - rotZ / 90));
            }
            
        }
        else
        { 
            if(rotZ < 0 && rotZ > -90)
            {
                if(temp == 0)
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
