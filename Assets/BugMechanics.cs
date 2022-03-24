using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMechanics : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject chip;

    private Vector3 lastFrameVelocity;
    private Rigidbody2D rb;

    private void Awake()
    {
        chip = this.transform.parent.transform.GetChild(0).gameObject;
    }
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(100f,10f);
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
        if(collision.gameObject.name != chip.name)
        {
        Vector3 normal = (chip.transform.position - transform.position).normalized;
        rb.velocity = Vector2.Reflect(rb.velocity, normal);
        print(rb.velocity);
        }
      
    }


    public void ClickedOn()
    { 
        print("you got the bug");
        gameObject.SetActive(false);
       
    }



}
