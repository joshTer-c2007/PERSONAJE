using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rd;
    public float speed = 5f;
    public float jumpForce = 7f;

    private bool isGrounded;
    
   void Start()
{
    rd = GetComponent<Rigidbody2D>();
    isGrounded = true; // Para que pueda saltar desde el primer segundo si empieza apoyado
}
    
    void Update()
    {
       float moveInput = Input.GetAxis("Horizontal");
        rd.linearVelocity = new Vector2(moveInput * speed, rd.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rd.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        } 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
