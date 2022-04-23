using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPan : MonoBehaviour
{
    public bool canPan;
   
    // Start is called before the first frame update
    void Start()
    {
        canPan = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    // called by the Animation Event in the Animator for CameraFollowTarget
    public void StartPan()
    {
        canPan = true;
    }
}
