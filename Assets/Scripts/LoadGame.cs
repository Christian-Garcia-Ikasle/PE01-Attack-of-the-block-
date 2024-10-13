using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry : MonoBehaviour
{
    //Ran
    public int top1;
    public int top2;
    public int top3;
    public int top4;
    public int top5;
    public TextMeshProUGUI rankText;

    public void Start()
    {
        //Load the ranking
        if (!PlayerPrefs.HasKey("top1"))
        {
            PlayerPrefs.SetInt("top1", 0);
        }
        top1 = PlayerPrefs.GetInt("top1");

        if (!PlayerPrefs.HasKey("top2"))
        {
            PlayerPrefs.SetInt("top2", 0);
        }
        top2 = PlayerPrefs.GetInt("top2");

        if (!PlayerPrefs.HasKey("top3"))
        {
            PlayerPrefs.SetInt("top3", 0);
        }
        top3 = PlayerPrefs.GetInt("top3");

        if (!PlayerPrefs.HasKey("top4"))
        {
            PlayerPrefs.SetInt("top", 0);
        }
        top4 = PlayerPrefs.GetInt("top4");

        if (!PlayerPrefs.HasKey("top5"))
        {
            PlayerPrefs.SetInt("top5", 0);
        }
        top5 = PlayerPrefs.GetInt("top5");

        //Sets life text
        rankText.SetText("Ranking : " + Environment.NewLine  + "Top 1 = " + top1 + Environment.NewLine + "Top 2 = " + top2 + Environment.NewLine + "Top 3 = " + top3 + Environment.NewLine +  "Top 4 = " + top4 + Environment.NewLine + "Top 5 = " + top5);
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
        //Sets life text
        rankText.SetText("Ranking : " + Environment.NewLine + "Top 1 = " + top1 + Environment.NewLine + "Top 2 = " + top2 + Environment.NewLine + "Top 3 = " + top3 + Environment.NewLine + "Top 4 = " + top4 + Environment.NewLine + "Top 5 = " + top5);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
