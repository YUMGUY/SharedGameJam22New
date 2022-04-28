using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vic_or_Fail : MonoBehaviour
{
    // Start is called before the first frame update

    // reference to hp bar
    public NGHealthBar hpbarRefVicFail;

    // reference to robot destinatioon flag

    public Rbt_Movement destFlag;


    // victory remove hud alpha
    public GameObject hudCanvas;
    private float durationH = 3f;
    private float timerH = 0;
    void Start()
    {
        destFlag = GameObject.Find("Robot (PLAYER)").GetComponent<Rbt_Movement>();
        hudCanvas = GameObject.FindGameObjectWithTag("hudCanvas");
        hpbarRefVicFail = GameObject.Find("HealthBar").GetComponent<NGHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (destFlag.reachedDestination == true)
        {
            timerH += Time.deltaTime;
            this.transform.GetChild(0).gameObject.SetActive(true);
            hudCanvas.GetComponent<CanvasGroup>().alpha = Mathf.Lerp(1, 0, timerH / durationH);
        }

        if (hpbarRefVicFail.hp <= 0)
        {
            // stop the robot from moving in the background
            destFlag.canMove = false;
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void GoToMenuScene()
    {
        SceneManager.LoadScene(0);
        return;
    }

  
}
