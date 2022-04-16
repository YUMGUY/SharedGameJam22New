using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recycleBinMechanics : MonoBehaviour
// Start is called before the first frame update
{
    private int numberOfChildren;
    private int total;
    private Button pressRecycle;
    public GameObject trash;


    private Vector2[] possibleLocationsTrash = {new Vector2(-100,0), new Vector2(-40,-37), 
                                                new Vector2(-140,20), new Vector2(-150,55), new Vector2(-205,-130),
                                                new Vector2(-10,66), new Vector2(0,0), new Vector2(-62,75) };
    private int[] positionsTrash = new int[8];

    private void Awake()
    {
       
    }
    void Start()
    {
        
       // pressRecycle = transform.GetChild(1).GetComponent<Button>();
    }

    private void OnEnable()
    {
        // could be in awake if the Gameobject is destroyed
        HashSet<int> hash = new HashSet<int>();
        while (hash.Count < 8)
        {
            hash.Add(Random.Range(0, 8));
        }

        hash.CopyTo(positionsTrash);

        numberOfChildren = transform.childCount;
        pressRecycle = transform.GetChild(2).GetComponent<Button>(); // the 2nd child of the task parent
        pressRecycle.interactable = false;

        // spawn 4 trash objects with different positions
        for(int i = 0; i < 4; ++i)
        {
            int trashIndex = positionsTrash[i];
            GameObject childTrash = Instantiate(trash, this.transform);
            childTrash.transform.localPosition = possibleLocationsTrash[trashIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {

        total = transform.childCount;

        for(int i = 0; i < transform.childCount; ++i)
        {
            if(transform.GetChild(i).gameObject.activeInHierarchy == false)
            {
                total -= 1;
            }
        }

        numberOfChildren = total;

        if(numberOfChildren == 3) // ONLY THE BIN AND BUTTON ARE LEFT
        {
           // print("you finished recycle");
            pressRecycle.interactable = true;
        }
       
    }

    // POTENTIAL BENEFIT FOR FINISHING THIS TASK FIRST SINCE IT HELPS THE COMPUTER
    public void ClickRecycle()
    {
        // give 3% BATTERY BACK WHEN RECYCLE TASK IS FINISHED?
    }

    
    
}
