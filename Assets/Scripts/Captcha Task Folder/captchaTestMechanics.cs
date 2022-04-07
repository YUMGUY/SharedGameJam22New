using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class captchaTestMechanics : MonoBehaviour
{
    [SerializeField]
    private captchaManager cManager;
    [SerializeField]
    private TMP_InputField refInput;


    // test if the player is really a robot
    public string playerInputCaptcha;
    public string correctCaptcha;
    public bool playerGiveCaptcha;
    // Start is called before the first frame update
    private void Awake()
    {
        cManager = GameObject.Find("Captcha Manager").GetComponent<captchaManager>();
        int index = Random.Range(0, cManager.locations.Length);

        this.transform.localPosition = cManager.locations[index];
    }

    private void OnEnable()
    {
        int index = Random.Range(0, cManager.captchaWords.Length);
        correctCaptcha = cManager.captchaWords[index];

        // reset
        playerGiveCaptcha = false;

    }

    private void OnDisable()
    {
        playerInputCaptcha = "";
        this.transform.GetChild(0).gameObject.GetComponent<TMP_InputField>().text = "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInputCaptcha == correctCaptcha && playerGiveCaptcha == true)
        {
            print("let's go you are a robot");
            // set inactive for now
            gameObject.SetActive(false);
        }

        else if(playerInputCaptcha != correctCaptcha && playerGiveCaptcha == true)
        {
            print("wrong captcha");
            playerGiveCaptcha = false;
        }
    }

    public void getCaptchaInput(string input)
    {
        playerInputCaptcha = input;
        playerGiveCaptcha = true;
    }
}
