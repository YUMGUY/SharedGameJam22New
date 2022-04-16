using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowObject : MonoBehaviour
{

    public bool canBePressedOn;
    public KeyCode keyToGetPressed;

    public phase2Mechanics decider;
    public bool correct;
    // Start is called before the first frame update
    void Start()
    {
        canBePressedOn = false;
        correct = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToGetPressed))
        {
            if(canBePressedOn == true)
            {
                decider.HitArrow();
                correct = true;
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "activator")
        {
            canBePressedOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "activator" && correct == false) // 75% SURE THIS WILL FIX THE ERROR WHERE SUCCESS AND FAIL AT THE SAME TIME
        {
            canBePressedOn = false;
            //print("missed arrow");
            decider.MissedArrow();
        }
    }
}
