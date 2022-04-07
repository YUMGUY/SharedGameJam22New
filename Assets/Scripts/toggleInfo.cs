using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class toggleInfo : MonoBehaviour
{
    [SerializeField]
    private Toggle infotoggle;

    private Color32 toggleOnColor = new Color32(85, 115, 255, 255);
    // Start is called before the first frame update

    private void Awake()
    {
        infotoggle = GetComponent<Toggle>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(infotoggle.isOn)
        {
            this.GetComponent<Image>().color = toggleOnColor;
        }

        else
        {
            this.GetComponent<Image>().color = Color.white;
        }
        
    }
}
