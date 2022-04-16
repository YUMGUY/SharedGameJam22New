using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class phase2ButtonControl : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode keyToPress;
    private Image original;

    void Start()
    {
        original = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // change color when the button is pressed for now, changing sprites for polish
        if(Input.GetKeyDown(keyToPress))
        {
            original.color = Color.green;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            original.color = Color.white;
        }
    }
}
