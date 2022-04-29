using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuCameraRotate : MonoBehaviour
{
    public float camSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, camSpeed * Time.deltaTime,0);
    }
}
