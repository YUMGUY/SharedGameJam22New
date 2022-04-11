using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NGHealthBar : MonoBehaviour
{
    public float hp;
    public float dps;
    public Text num;
    public Image active;
    public Sprite hb100;
    public Sprite hb80;
    public Sprite hb60;
    public Sprite hb40;
    public Sprite hb20;
    public Sprite hb0;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        active.sprite = hb80;
        

    }

    // Update is called once per frame
    void Update()
    {
        hp += -Time.deltaTime * dps;
        if (hp <= 0)
        {
            active.sprite = hb0;
        }
        else
            if(hp <= 20)
            {
                active.sprite = hb20;
            }
            else
                if(hp <= 40)
                {
                    active.sprite = hb40;
                }
                else
                    if(hp <= 60)
                    {
                        active.sprite = hb60;
                    }
                    else
                        if(hp <= 80)
                        {
                            active.sprite = hb80;
                        }
                        else
                        {
                            active.sprite = hb100;
                        }

        num.text = hp.ToString("F2");
    }

    void addHealth(float bonus)
    {
        hp += bonus;
    }
}
