using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
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
        //This is to make the cursor disapear
        Cursor.visible = false;
        //Audio source selected
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //Con las siguientes lineas el personaje seguira a el raton

        Vector3 posicionRaton = Input.mousePosition;
        posicionRaton = Camera.main.ScreenToWorldPoint(posicionRaton);
        transform.position = new Vector3(posicionRaton.x, posicionRaton.y, 0);
       
    }

    //Aqui le especifico que si le tocan pierde
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
            if(vidas <= 0)
            {
            audioSource.clip = sounds[1];
            audioSource.Play();
            SceneManager.LoadScene("GameOver");
            Cursor.visible = true;
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
