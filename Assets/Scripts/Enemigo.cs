using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Genero un pequeño impulso al empezar para que rebote en las diferentes paredes en vez de solo en el suelo y techo.
        Vector2 Empuje = new  (1,3);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(Empuje*300);
    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
        
        if (collision.gameObject.CompareTag("Limit"))
        {
            audioSource.Play();
        }
     }

}
