using UnityEngine;
using UnityEngine.InputSystem;

public class Climb : MonoBehaviour
{
    public float climbSpeed = 5f;
    public static bool isClimbing;
    public static bool isLadder;
    public static bool isPlatform;
    private float vertical;
    [SerializeField]private Rigidbody2D rb;


    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical"); // W/S or Up/Down
        if (isLadder && Mathf.Abs(vertical) > 0 && isPlatform)
        {
            isClimbing = true;
        }
        
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, vertical * climbSpeed);
            rb.gravityScale = 0f; // Disable gravity while climbing
        }
        else
        {
            rb.gravityScale = 1f; // Enable gravity when not climbing
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = true;
            gameObject.layer = LayerMask.NameToLayer("PlayerClimbing");


        }
        if (collision.CompareTag("Platform"))
        {
            isPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isClimbing = false;
            isLadder = false;
            gameObject.layer = LayerMask.NameToLayer("PlayerNormal");


        }
        
    }
}
