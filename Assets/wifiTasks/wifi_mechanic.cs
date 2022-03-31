using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class wifi_mechanic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update

    private bool selected;
    private string playerInput;

    private float startPosXWifi;
    private float startPosYWifi;

    public wifi_pw_setter wifiTask;
    void Start()
    {
        wifiTask = GameObject.Find("Wifi Password Setter").GetComponent<wifi_pw_setter>();
    }

    // Update is called once per frame
    void Update()
    {
        if(selected == true)
        {
            Vector3 mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosXWifi, mousePos.y - startPosYWifi);
        }

        if (playerInput == wifiTask.passwordUsed)
        {
            Debug.Log("yatta");
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        playerInput = "";
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

        Debug.Log(playerInput);

    }
}
