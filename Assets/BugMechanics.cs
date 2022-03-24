using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject chip;
    public GameObject parent;
    private Vector3 lastFrameVelocity;
    private Rigidbody2D rb;


 
    private void Awake()
    {
        chip = this.transform.parent.transform.GetChild(0).gameObject;
        parent = this.transform.parent.gameObject;
    }
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
     
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastFrameVelocity = rb.velocity;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        //print(collision.gameObject.name);
        if(collision.gameObject.name == parent.name)
        {
        Vector3 normal = (chip.transform.position - transform.position).normalized;
        rb.velocity = Vector2.Reflect(rb.velocity, normal);
      
        }
      
    }


    public void ClickedOn()
    { 
        print("you got the bug");
        gameObject.SetActive(false);
       
    }



}
