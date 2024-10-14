using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Ranking : MonoBehaviour
{
    //Load ranking
    public int top1;
    public int top2;
    public int top3;
    public int top4;
    public int top5;
    public TextMeshProUGUI rankText;

    // Start is called before the first frame update
    void Start()
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
            PlayerPrefs.SetInt("top4", 0);
        }
        top4 = PlayerPrefs.GetInt("top4");

        if (!PlayerPrefs.HasKey("top5"))
        {
            PlayerPrefs.SetInt("top5", 0);
        }
        top5 = PlayerPrefs.GetInt("top5");

        //Sets life text
        rankText.SetText("Ranking : " + System.Environment.NewLine  + "Top 1 = " + top1 + System.Environment.NewLine + "Top 2 = " + top2 + System.Environment.NewLine + "Top 3 = " + top3 + System.Environment.NewLine +  "Top 4 = " + top4 + System.Environment.NewLine + "Top 5 = " + top5);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
