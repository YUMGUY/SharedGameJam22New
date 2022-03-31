using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class wifi_pw_setter : MonoBehaviour
{
    // Start is called before the first frame update

    private string[] passwords = { "megu_megu_fire2011", "SayRefrigerator101", "HelloWorld1" };

    public string passwordUsed;

    public GameObject infoPageWifiText;


    private void Awake()
    {
        int index = Random.Range(0, 3);
        passwordUsed = passwords[index];
        infoPageWifiText.GetComponent<TextMeshProUGUI>().text = passwordUsed;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
