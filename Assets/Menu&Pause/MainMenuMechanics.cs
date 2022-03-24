using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuMechanics : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitTheGame()
    {   
        Debug.Log("you quit :(");
        Application.Quit();
        
    }
}
