using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Flag_Mech : MonoBehaviour
{
    // Start is called before the first frame update

    public bool gameStartedIntro;
    void Start()
    {
        gameStartedIntro = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDelivery()
    {
        gameStartedIntro = true;
    }
}
