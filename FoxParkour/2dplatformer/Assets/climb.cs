using UnityEngine;
using UnityEngine.InputSystem;

public class Climb : MonoBehaviour
{
    public float climbSpeed = 5f;
    public static bool isClimbing = false;
    private float vertical;
    private Rigidbody2D rb;
    
   
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        if (isClimbing)
        {
            vertical = Input.GetAxisRaw("Vertical"); // W/S or Up/Down
        }

        else
        {
            vertical = 0f;


        }
    }

    void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f; // disable gravity while climbing
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * climbSpeed);
        }
        else
        {
            rb.gravityScale = 1f; // restore gravity


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
            
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            
        }
    }
}
