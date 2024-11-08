using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Velocità del personaggio
    public float jumpForce = 10f;
    private Rigidbody2D rb; // Riferimento al Rigidbody2D del personaggio
    private Vector2 movement; // Vettore per memorizzare il movimento
    private bool isGrounded; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // Input asse X
        movement = new Vector2(moveX, 0); // Crea il vettore di movimento

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            Debug.Log("ciao");
        }
    }

        void FixedUpdate()
    {
        // Applica il movimento in base alla velocità e al tempo fisso
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

        void Jump()
    {
        // Applica una forza verso l'alto per il salto usando Rigidbody2D
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        isGrounded = false;  // Il player non è più a terra dopo il salto
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se il player tocca il pavimento
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
