using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phase1part2 : MonoBehaviour
{
    // Start is called before the first frame update
    //We need an Image Variable so the script knows what image to change
    public Image clickMeter;

    //We need variables for the maximum the meter can fill and also the current meter number.
    public float curMeter, maxMeter;

    //We need a variable that increases the value of the meter
    public float incMeter;

    //We also need a float that decreases the value of the meter.
    public float decMeter;

    //add a new float to determine the time between taps
    public float meterReduceTimer;

    //reduce
    public float timeBetweenClicks;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ImageChange();
        MaxMinValue();
        TappingKey();
        ReduceMeter();
        if(clickMeter.fillAmount >= 1)
        {
            // set parent object to inactive

            this.gameObject.transform.parent.gameObject.SetActive(false);
        }
        
    }

    void TappingKey()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            curMeter += incMeter;
            meterReduceTimer = 0;
        }
    }

    void ReduceMeter()
    {
        //Meter Reduce Timer will increase by one every frame, this is very fast,
        //so let's give a bit of leeway before the meter decreases. 10 frames seems nice.

        meterReduceTimer += 1;
        if (meterReduceTimer > timeBetweenClicks)
        {
            curMeter -= decMeter;
        }
    }

    void ImageChange()
    {
        //The image fill amount is CurrentMeter divided by MaxMeter
        clickMeter.fillAmount = curMeter / maxMeter;
    }

    void MaxMinValue()
    {

        //if current meter is less than 0 then current meter equals 0.
        //if current meter is more than max meter then current meter equals max meter

        if (curMeter < 0)
        {
            curMeter = 0;
        }
        else if (curMeter > maxMeter)
        {
            curMeter = maxMeter;
        }
    }
}
