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

    public Image taskWindow;

    public bool answered;

    private bool flashedRed = false;

    

    void Start()
    {
        wifiTask = GameObject.Find("Wifi Password Setter").GetComponent<wifi_pw_setter>();
        // inputFieldref = this.transform.GetChild(0).gameObject.GetComponent<InputField>();
        child1 = this.transform.GetChild(0).gameObject;
        inputref = child1.GetComponent<TMP_InputField>();
        taskWindow = this.transform.GetChild(0).GetComponent<Image>();

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
           // Debug.Log("wrong password");
            if(flashedRed == false)
            {
                StartCoroutine(flashRedWifi());
                flashedRed = true;
            }

            inputref.text = "";
            answered = false;
        }
    }

   
    private void OnDisable()
    {
        playerInput = "";
        inputref.text = "";
        flashedRed = false;
        
    }

    private void OnEnable()
    {
        // randomize locations of wifi task
        this.transform.localPosition = new Vector2(Random.Range(-200, 200), Random.Range(-200, 200));

        answered = false;
    }

    // DRAGGABLE CODE
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

    // INPUT FIELD ON END 
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

    // INPUT FIELD ON DESELECT
    public void deselected()
    {
        answered = false;

    }

    public IEnumerator flashRedWifi()
    {
        float duration = .5f;
        float timer = 0f;

        while(timer <= .5f)
        {
            timer += Time.deltaTime;
            taskWindow.color = Color.Lerp(Color.white, Color.red, timer/duration);
            yield return null;
        }
        timer = 0f;

        while(timer <= .5f)
        {
            timer += Time.deltaTime;
            taskWindow.color = Color.Lerp(Color.red,Color.white, timer / duration);
            yield return null;
        }


        
        print("done flash red");
        flashedRed = false;
        yield return null;

    }
}
