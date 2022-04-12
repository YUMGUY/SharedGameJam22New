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
        rotSpeed = 10 + temp;
        if(temp > 0)  //this elif will decrement both rotation and heat
        {

            if(heat <= 0)
            {
                rotZ = -90;
                heat = 0;
            }
            else
            {
                if (heat >= 50) 
                {
                    //print("function 1");
                    rotZ += -Time.deltaTime * rotSpeed;
                    heat = 100 - temp * (50 * (1 - rotZ / 90));
                    
                }
                else
                {
                    //print("function 2");
                    rotZ += -Time.deltaTime * rotSpeed;
                    heat = 50 + temp * (50 * (rotZ / 90));
                    
                }
            }
            
            
        }
        else
        {
            if (rotZ >= 90)//these are the elifs to increase the heat
            {
                rotZ = 90;
                heat = 100;
            }
            else
            {
                if (heat >= 50) 
                {
                    //print("function 3");
                    rotZ += Time.deltaTime * rotSpeed;
                    heat = 100 +  (50 * (1 - rotZ / 90));
                   
                }
                else
                {
                    //print("function 4");
                    rotZ += Time.deltaTime * rotSpeed;
                    heat = 50 +  (50 * (rotZ / 90));
                    
                }
            }
        }
       
        transform.rotation = Quaternion.Euler(0,0,rotZ);
    }


    public float getHeat()
    {
        return heat;
    }

    public void setHeat(float damage)
    {
        heat = heat - damage;
    }
}
