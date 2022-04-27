using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class phase1Mechanics : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{   
    // FOR PHASE 1
    public carEventManager carEventOrigin;

    [SerializeField]
    private bool pressedDown;
    [SerializeField]
    private bool phase1_barCompleted;
    [SerializeField]
    private float heldTime;
    public float holdTime;
    
    public Image powerbarFilled;

    // code for hold long click
    public UnityEvent holdLongClick;

    [Header("Change Text Reference")]
    public TextMeshProUGUI promptText;

    
// Start is called before the first frame update


    void Start()
    {
        carEventOrigin = GameObject.Find("Car Event Manager").GetComponent<carEventManager>();
        pressedDown = false;
        phase1_barCompleted = false;
        promptText = this.transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        // FOR PHASE 1 PART 1
        if(pressedDown == true)
        {
            heldTime += Time.deltaTime;
            powerbarFilled.fillAmount = heldTime / holdTime;
        }

        if(heldTime >= holdTime)
        {   
            if(holdLongClick != null)
            {
                promptText.text = "Jumpstart the Hydroplasma Engine!";
                holdLongClick.Invoke();
            }
           
            phase1_barCompleted = true;
            powerbarFilled.fillAmount = 1;
            
        }

        

       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("you pressed it");
        pressedDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(phase1_barCompleted == false)
        {
            ResetBar();
            print("reset the bar");
        }
    }

    public void ResetBar()
    {
        pressedDown = false;
        heldTime = 0;
        powerbarFilled.fillAmount = heldTime / holdTime;
    }
}
