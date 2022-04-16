using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScroller : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasStarted;
    void Start()
    {
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(hasStarted == false)
        {
            if(Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        
        else
        {
            transform.position -= new Vector3(0, 20 * Time.deltaTime);
        }
    }
}
