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

public class PlayerController : MonoBehaviour
{
    //The variable for the score
    public int score = 0;
    public TextMeshProUGUI scoreText;

    //The variables for top 5 ranking
    public int top1;
    public int top2;
    public int top3;
    public int top4;
    public int top5;

    //The variable for lifes
    public TextMeshProUGUI lifeText;
    int vidas = 3;

    //Audio source and sound array declaration
    private AudioSource audioSource;
    public AudioClip[] sounds;

    // Invulnerability variables, time + boolean
   public float damageDelay = 1.0f;
   public float guardTime = 15.0f;
   private bool invulnerable = false;

    void Start()
    {   
        //Sets life text
        lifeText.SetText("Life Points : " + vidas);

        //This is to make the cursor disapear
        Cursor.visible = false;

        //Audio source selected
        audioSource = GetComponent<AudioSource>();

        //Get the top 5 scores from palyerprefs
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
    }
    // Update is called once per frame
    void Update()
    {
        //this mekes the character follow the cursor
        if(Time.timeScale==0)
        {
            return;
        }

        //Adds points to the final score
        score++;
        scoreText.SetText("Score : "+score);

        //this mekes the character follow the cursor
        Vector3 posicionRaton = Input.mousePosition;
        posicionRaton = Camera.main.ScreenToWorldPoint(posicionRaton);
        transform.position = new Vector3(posicionRaton.x, posicionRaton.y, 0);
       
    }

    //This controls what happens when the character gets hit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDamage();
        }
        
        if(collision.gameObject.CompareTag("GuardPU"))
        {
            invulnerable = true;
            CancelInvoke(nameof(DisableInvincibility));
            Invoke(nameof(DisableInvincibility),guardTime);
            Destroy(collision.gameObject);
        }
    }

    //Invincibility frames start
    public void OnDamage()
   {
       if (invulnerable) return;
       invulnerable = true;
       vidas--;
       lifeText.SetText("Life Points : "+vidas);
            
            if(vidas <= 0)
            {
            audioSource.clip = sounds[1];
            audioSource.Play();
            Cursor.visible = true;

            //Update top 5 scores value
            if (score > top1)
            {
                top5 = top4;
                top4 = top3;
                top3 = top2;
                top2 = top1;
                top1 = score;
            }

            if (score > top2 && score < top1)
            {
                top5 = top4;
                top4 = top3;
                top3 = top2;
                top2 = score;
            }

            if (score > top3 && score < top2)
            {
                top5 = top4;
                top4 = top3;
                top3 = score;
            }

            if (score > top4 && score < top3)
            {
                top5 = top4;
                top4 = score;
            }

            if (score > top5 && score < top4)
            {
                top5 = score;
            }
            
            //Saves the top 5 scores
            PlayerPrefs.SetInt("top1", top1);
            PlayerPrefs.SetInt("top2", top2);
            PlayerPrefs.SetInt("top3", top3);
            PlayerPrefs.SetInt("top4", top4);
            PlayerPrefs.SetInt("top5", top5);

            //Loads game over scene
            SceneManager.LoadScene("GameOver");
          
           // use playerprefs to save the score
            } else
            {
            audioSource.clip = sounds[0];
            audioSource.Play();
            }
        CancelInvoke(nameof(DisableInvincibility));
        Invoke(nameof(DisableInvincibility),damageDelay);
   }

   //Invicibility timer function
   private void DisableInvincibility()
   {
       invulnerable = false;
   }
}
