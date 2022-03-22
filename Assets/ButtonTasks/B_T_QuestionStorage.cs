using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_T_QuestionStorage : MonoBehaviour
{
    // Start is called before the first frame update

    // the index of each array correspond to each other, paired
    public string[] questions;
    public int[] answersManager;

    public GameObject simpleBtask1;

    public Transform parentCanvas;

    public float timer;
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        // RN INSTANTIATION BC SPAWNING IS NOT GONNA BE THAT INTENSIVE FOR OUR GAME RIGHT NOW
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            GameObject Btask1 = Instantiate(simpleBtask1,parentCanvas);

            // can change later, this is temporary
            Btask1.transform.localPosition = new Vector2(Random.RandomRange(-200,200),Random.RandomRange(-200,200));
            timer = 5f;
        }


        // either instantitate or setactive from pool
    }
}
