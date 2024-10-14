using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    
    public void Start()
    {
            }
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        Cursor.visible = true;
    }
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}