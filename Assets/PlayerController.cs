using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();    ;
        }
    }
}
