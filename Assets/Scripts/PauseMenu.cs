using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PauseMenu : MonoBehaviour
{
    //The variable to manage the state of the pause screen
    private bool isPaused; 
    public GameObject pauseMenu ;
    void Update()
    {
        print("Ejecuta");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //This toggles pause state on Escape key press
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        // This sets Time.timeScale to 0 to pause gameplay
        Time.timeScale = 0;
        // This makes the PauseMenu panel visible
        pauseMenu.gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        // This sets Time.timeScale back to 1 to resume gameplay
        Time.timeScale = 1;
        //This hides the PauseMenu panel 
        pauseMenu.gameObject.SetActive(false);
    }
}