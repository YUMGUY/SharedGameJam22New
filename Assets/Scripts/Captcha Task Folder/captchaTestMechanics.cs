using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class captchaTestMechanics : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private captchaManager cManager;
    [SerializeField]
    private TMP_InputField refInput;

    [Header("Captcha Text")]
    [SerializeField]
    private TextMeshProUGUI textCaptcha;
    [SerializeField]
    private GameObject captchaTextBox;

    // test if the player is really a robot
    public string playerInputCaptcha;
    public string correctCaptcha;
    public bool playerGiveCaptcha;


    // making it draggable
    private bool selectedCap;
  

    private float startPosXCap;
    private float startPosYCap;

    // Start is called before the first frame update
    private void Awake()
    {
        cManager = GameObject.Find("Captcha Manager").GetComponent<captchaManager>();
        int index = Random.Range(0, cManager.locations.Length);

        // randomize locations of captcha task
        this.transform.localPosition = cManager.locations[index];


        captchaTextBox = this.transform.GetChild(2).gameObject;

        textCaptcha = captchaTextBox.GetComponent<TextMeshProUGUI>();
        refInput = GetComponentInChildren<TMP_InputField>();

        
    }

    private void OnEnable()
    {
        int index = Random.Range(0, cManager.captchaWords.Length);
        correctCaptcha = cManager.captchaWords[index];

        // set correct captcha word to visible
        textCaptcha.text = correctCaptcha;

        // reset
        playerGiveCaptcha = false;

    }

    private void OnDisable()
    {
        playerInputCaptcha = "";
       // this.transform.GetChild(0).gameObject.GetComponent<TMP_InputField>().text = "";
        refInput.text = "";
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // for dragging
        if (selectedCap == true)
        {
            Vector3 mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosXCap, mousePos.y - startPosYCap);
        }

        // for gameplay
        if (playerInputCaptcha == correctCaptcha && playerGiveCaptcha == true)
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

    // DRAGGABLE CODE
    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 mousePos1 = Input.mousePosition;
        //mousePos1 = Camera.main.ScreenToViewportPoint(mousePos1);
        startPosXCap = mousePos1.x - this.transform.localPosition.x;
        startPosYCap = mousePos1.y - this.transform.localPosition.y;
        selectedCap = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selectedCap = false;

    }

}
