using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class taskErrorBehavior : MonoBehaviour
{
    [Header("Reference to HP Bar")]
    public float healthReference;


    [Header("Flashing Colors")]
    public Color[] colorsError;


    // 2 types of movement

    public Vector3 startingPosition;
    private float offsetPosition;
    private float positionTimer;

    // flashing colors
    [SerializeField]
    private int colorIndex = 0;
    private Image thisWindow;

    private float colorTime;
    private int colorArrayLength;
    // choose 1, 2, or 3 : 1 is sideways, 2 is up and down, 3 is flashing colors
    public int chooseErrorReaction = 0;
    private int errorState;



    // Start is called before the first frame update
    void Start()
    {
        colorIndex = 0;
        healthReference = GameObject.Find("HealthBar").GetComponent<NGHealthBar>().hp;
        thisWindow = GetComponent<Image>();
        colorArrayLength = colorsError.Length;

        startingPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        


        // flashing color error state
        if(chooseErrorReaction == 1)
        {
            thisWindow.color = Color.Lerp(thisWindow.color, colorsError[colorIndex], 2f * Time.deltaTime);
            colorTime = Mathf.Lerp(colorTime, 1f, 2f * Time.deltaTime);

            if(colorTime >= .95f)
            {
                colorTime = 0f;
                colorIndex++;
                colorIndex = (colorIndex >= colorArrayLength) ? 0 : colorIndex;
            }

        }

        // move sideways
        else if (chooseErrorReaction == 2)
        {
            positionTimer += Time.deltaTime;
            offsetPosition = 50f * Mathf.Sin(positionTimer * 1f * Mathf.PI);
            transform.localPosition = startingPosition + new Vector3(offsetPosition, 0f, 0f);
        }

        // move up and down
        else if (chooseErrorReaction == 3)
        {
            positionTimer += Time.deltaTime;
            offsetPosition = 50f * Mathf.Sin(positionTimer * 1f * Mathf.PI);
            transform.localPosition = startingPosition + new Vector3(0f, offsetPosition, 0);
        }
    }

    public void OnEnable()
    {
        healthReference = GameObject.Find("HealthBar").GetComponent<NGHealthBar>().hp;
        positionTimer = 0f;

        // have a 70% chance to get an error state for this task if battery is at 50% at the time the task is created
        errorState = Random.Range(0, 100);
        print(errorState);
        if(healthReference <= 50 && errorState <= 70)
        {
            // chooses 1 to 3
            chooseErrorReaction = Random.Range(1, 4);
            print("choose: " + chooseErrorReaction);
            //chooseErrorReaction = 1;
        }

        // no error state
        else
        {
            chooseErrorReaction = 0;
        }
    }



    //public IEnumerator flashingColors()
    //{

    //    float timerE = 0;



    //    yield return null;
    //}
}
