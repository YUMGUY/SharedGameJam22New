using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    public bool exploded;
    private Vector3 speedCar = new Vector3(0, 0, 1.2f);
    public Rbt_Movement rbtMove;
    //private float durationt = 100f;
   // private float timerer = 0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        exploded = false;
        rbtMove = GameObject.Find("Robot (PLAYER)").GetComponent<Rbt_Movement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!exploded && rbtMove.indexWaypoint >= 6)
            rb.velocity = speedCar;

        else if (rbtMove.indexWaypoint < 6)
        {
            rb.velocity = Vector3.zero;
        }

        
            
    }

    // WORKS, now instead of onMouse, do if position == position of robot// THIS IS FOR TESTING
    //private void OnMouseDown()
    //{
    //    exploded = true;
    //    this.GetComponent<Rigidbody>().AddExplosionForce(1000f, new Vector3(-1, -1f, -1f), 15f,3f);
        
    //    this.GetComponent<Rigidbody>().useGravity = true;
    //    print("clicked on");
    //}

    
}
