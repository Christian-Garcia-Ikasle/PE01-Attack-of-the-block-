using UnityEngine;

public class Enemigo : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //Generates a small burst in the enemy so they get to hit the walls and rebound
        Vector2 Empuje = new  (1,3);
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(Empuje*300);
    }

    //Sounds on hitting the walls
     private void OnTriggerEnter2D(Collider2D collision)
     {
        
        if (collision.gameObject.CompareTag("Limit"))
        {
            audioSource.Play();
        }
     }

}
