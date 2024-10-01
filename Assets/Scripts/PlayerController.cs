using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class PlayerController : MonoBehaviour
{
    int vidas = 3;
    private bool isInvincible;
    private float invincibilityDurationSeconds = 10;
    private float delayBetweenInvincibilityFlashes = 2;

    void Start()
    {
        
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
            vidas--;
            if(vidas <= 0)
            {
            SceneManager.LoadScene("GameOver");
            } 
            BecomeTemporarilyInvincible();
        }
    }

    private IEnumerator BecomeTemporarilyInvincible()
    {
        UnityEngine.Debug.Log("Player turned invincible!");
        isInvincible = true;

        // Flash on and off for roughly invincibilityDurationSeconds seconds
        for (float i = 0; i < invincibilityDurationSeconds; i += delayBetweenInvincibilityFlashes)
        {
            // TODO: add flashing logic here
            yield return new WaitForSeconds(delayBetweenInvincibilityFlashes);
        }

        UnityEngine.Debug.Log("Player is no longer invincible!");
        isInvincible = false;
    }
}
