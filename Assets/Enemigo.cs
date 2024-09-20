using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Genero un pequeño impulso al empezar para que rebote en las diferentes paredes en vez de solo en el suelo y techo.
        Vector2 Empuje = new  (1,3);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(Empuje*300);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
