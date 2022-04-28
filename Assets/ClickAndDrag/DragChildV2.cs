using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragChildV2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isSelected3 = false;
    public bool isCompleted3 = false;
    public GameObject socket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        socket = this.transform.parent.GetChild(1).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (isSelected3 == true)
        {
            this.transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        isSelected3 = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // the margin of error allowed for completing the task
        isSelected3 = false;
        //print(this.transform.localPosition);
        if (Vector2.Distance(this.transform.localPosition, socket.transform.localPosition) <= 12f)
        {
            isCompleted3 = true;
        }


    }
}
