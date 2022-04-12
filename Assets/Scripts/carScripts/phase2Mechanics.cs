using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phase2Mechanics : MonoBehaviour
{
    

    // FOR PHASE 2
    public carEventManager carEventOrigin2;
    
    // Start is called before the first frame update
    void Start()
    {
        carEventOrigin2 = GameObject.Find("Car Event Manager").GetComponent<carEventManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
