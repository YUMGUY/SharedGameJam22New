using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndRestart : MonoBehaviour
{

    public static bool willPause = false;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (willPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }

        }
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        willPause = false;
    }

    private void PauseGame()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
        willPause = true;
    }
}
