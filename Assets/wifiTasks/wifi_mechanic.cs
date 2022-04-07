using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;



public class wifi_mechanic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    private bool selected;
    private string playerInput;

    private float startPosXWifi;
    private float startPosYWifi;

    [SerializeField]
    private GameObject child1;

    public TMP_InputField inputref;
    public wifi_pw_setter wifiTask;

    public bool answered;

    void Start()
    {
        wifiTask = GameObject.Find("Wifi Password Setter").GetComponent<wifi_pw_setter>();
        // inputFieldref = this.transform.GetChild(0).gameObject.GetComponent<InputField>();
        child1 = this.transform.GetChild(0).gameObject;
        inputref = child1.GetComponent<TMP_InputField>();
       

    }

    // Update is called once per frame
    void Update()
    {
        if(selected == true)
        {
            Vector3 mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosXWifi, mousePos.y - startPosYWifi);
        }

        if (playerInput == wifiTask.passwordUsed && answered == true)
        {
            Debug.Log("yatta");
           
            gameObject.SetActive(false);
        }

        else if(playerInput != wifiTask.passwordUsed && answered == true)
        {
            // reset text
            Debug.Log("wrong password");
            inputref.text = "";
            answered = false;
        }
    }

   
    private void OnDisable()
    {
        playerInput = "";
        inputref.text = "";

        
    }

    private void OnEnable()
    {
        this.transform.localPosition = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));
        answered = false;
    }
    public void OnPointerDown(PointerEventData eventData) {
        Vector3 mousePos1 = Input.mousePosition;
        //mousePos1 = Camera.main.ScreenToViewportPoint(mousePos1);
        startPosXWifi = mousePos1.x - this.transform.localPosition.x;
        startPosYWifi = mousePos1.y - this.transform.localPosition.y;
        selected = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selected = false;

    }

    public void readInput(string s)
    {
        playerInput = s;
       // answered = true;
        Debug.Log(playerInput);

    }

    public void finishInput()
    {
        answered = true;
    }

    public void deselected()
    {
        answered = false;

    }
}
