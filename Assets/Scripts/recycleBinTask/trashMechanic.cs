using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class trashMechanic : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    private bool selectedTrash;
    private float startPosXTrash;
    private float startPosYTrash;
    Vector2 bin = new Vector2(120, 0);

    private Vector2[] placements = { new Vector2(0, 50), new Vector2(30,0), new Vector2(-100,20)};
    void Start()
    {
        
    }

    void Update()
    {
        // move the trash back into the window
        if(this.transform.localPosition.x <= -250f || transform.localPosition.x >= 250f || transform.localPosition.y <= -170f || transform.localPosition.y >= 170f)
        {
            int index = Random.Range(0, placements.Length);
            transform.localPosition = placements[index];
        }

        if (selectedTrash == true)
        {
            Vector3 mousePos = Input.mousePosition;
            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosXTrash, mousePos.y - startPosYTrash);
        } 

        else if(selectedTrash == false)
        {
            if (Vector2.Distance(this.transform.localPosition, bin) <= 50f)
            {
                print("you threw it in the bin");
                this.gameObject.SetActive(false);
            }
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 mousePos1 = Input.mousePosition;
        //mousePos1 = Camera.main.ScreenToViewportPoint(mousePos1);
        startPosXTrash = mousePos1.x - this.transform.localPosition.x;
        startPosYTrash = mousePos1.y - this.transform.localPosition.y;
        selectedTrash = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selectedTrash = false;

    }
}
