using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class phase1Flags : MonoBehaviour
{
   
    public float maxTime;
    public float timePassed; 

    // variable for timer image
    public Image timerBar;
    public carEventManager carFlag;

    private bool startFailureCoroutine;
    // Start is called before the first frame update
    
    void Start()
    {
        maxTime = 10f;
        carFlag = GameObject.Find("Car Event Manager").GetComponent<carEventManager>();
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        timePassed += Time.deltaTime;
        timerBar.fillAmount = (maxTime - timePassed) / maxTime;
        if(timerBar.fillAmount <= 0 && startFailureCoroutine == false)
        {
            // for failure
            carFlag.phase1Fail = true;
            StartCoroutine(Failure());
            startFailureCoroutine = true;
        }

    }

    // SCUFFED BUT IT WORKS
    public IEnumerator Failure()
    {
        yield return new WaitForSeconds(.1f);
        this.gameObject.SetActive(false);
    }
}
