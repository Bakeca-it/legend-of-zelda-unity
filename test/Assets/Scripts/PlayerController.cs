using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocità del personaggio
    private Rigidbody2D rb; // Riferimento al Rigidbody2D del personaggio
    private Vector2 movement; // Vettore per memorizzare il movimento

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ricevi input dall'utente (tasti W, A, S, D o frecce)
        float moveX = Input.GetAxis("Horizontal"); // Input asse X
        float moveY = Input.GetAxis("Vertical"); // Input asse Y
        movement = new Vector2(moveX, moveY); // Crea il vettore di movimento
    }

        void FixedUpdate()
    {
        // Applica il movimento in base alla velocità e al tempo fisso
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
