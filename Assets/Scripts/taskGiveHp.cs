using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskGiveHp : MonoBehaviour
{
    // Start is called before the first frame update
    public NGHealthBar hpBarrefTask;
    public float addHP;
    void Start()
    {
        hpBarrefTask = GameObject.Find("HealthBar").GetComponent<NGHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        hpBarrefTask.addHealth(addHP);
    }
}
