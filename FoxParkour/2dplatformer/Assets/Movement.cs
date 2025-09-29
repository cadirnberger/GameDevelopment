using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5f;         
    public float acceleration = 10f;     
    public float deceleration = 15f;     
    public float jumpForce = 5f;         
    private Rigidbody2D rb;
    private float targetSpeed;           
    private float currentSpeed;
    public UIDocument uiDocument;
    private Label winLabel;
    private Label collectionLabel;
    int cherries = 0;
    int total = 4;
    public GameObject runAnimation;
    public GameObject runAnimation2;
    public GameObject runAnimation3;
    public GameObject runAnimation4;
    public GameObject runAnimation5;
    public GameObject runAnimation6;
    
    public GameObject idleAnimation;
    public GameObject idleAnimation2;
    public GameObject idleAnimation3;
    public GameObject idleAnimation4;
    public GameObject jumpAnimation;
    public GameObject crouchAnimation;
    public GameObject fallAnimation;
    public GameObject climbAnimation;
    public GameObject climbAnimation2;
    public GameObject climbAnimation3;
    private float runAnimTimer = 0f;
    public float runAnimSpeed = 0.1f; 
    private int runAnimIndex = 0;
    private GameObject[] runAnimations;
    private float idleAnimTimer = 0f;
    public float idleAnimSpeed = 0.1f; 
    private int idleAnimIndex = 0;
    private GameObject[] idleAnimations;
    private float climbAnimTimer = 0f;
    public float climbAnimSpeed = 1f; 
    private int climbAnimIndex = 0;
    private GameObject[] climbAnimations;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        collectionLabel = uiDocument.rootVisualElement.Q<Label>("Collection");
        collectionLabel.text = "Cherries Left: " + cherries + "/" + total;
        runAnimations = new GameObject[] { runAnimation, runAnimation2, runAnimation3, runAnimation4, runAnimation5, runAnimation6 };
        idleAnimations = new GameObject[] { idleAnimation, idleAnimation2, idleAnimation3, idleAnimation4 };
        climbAnimations = new GameObject[]{ climbAnimation, climbAnimation2, climbAnimation3};

        idleAnimation.SetActive(true);
        foreach (var anim in runAnimations) anim.SetActive(false);
        foreach (var climb in climbAnimations) climb.SetActive(false);
        jumpAnimation.SetActive(false);
        fallAnimation.SetActive(false);
        crouchAnimation.SetActive(false);
    }

    void Update()
{
    float horizontalInput = 0f;

    // Handle horizontal movement
    if (Keyboard.current.dKey.isPressed)
        horizontalInput = 1f;
    else if (Keyboard.current.aKey.isPressed)
        horizontalInput = -1f;

    targetSpeed = horizontalInput * maxSpeed;
    if (horizontalInput > 0)
    transform.localScale = new Vector3(.4519303f, .7109098f, 1f); 
    else if (horizontalInput < 0)
    transform.localScale = new Vector3(-.4519303f, .7109098f, 1f); 

    if (Keyboard.current.wKey.wasPressedThisFrame && Mathf.Abs(rb.linearVelocity.y) < 0.001f)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    // Handle crouching (stop instantly)
    bool isCrouching = false;
    if (Keyboard.current.sKey.isPressed)
    {
        targetSpeed = 0f;
        currentSpeed = 0f;
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        isCrouching = true;
    }

        // Update animation based on state
        if (isCrouching && !Climb.isClimbing)
        {
            crouchAnimation.SetActive(true);
            idleAnimation.SetActive(false);
            idleAnimation2.SetActive(false);
            idleAnimation3.SetActive(false);
            idleAnimation4.SetActive(false);
            runAnimation.SetActive(false);
            runAnimation2.SetActive(false);
            runAnimation3.SetActive(false);
            runAnimation4.SetActive(false);
            runAnimation5.SetActive(false);
            jumpAnimation.SetActive(false);
            fallAnimation.SetActive(false);
            climbAnimation.SetActive(false);
            climbAnimation2.SetActive(false);
            climbAnimation3.SetActive(false);


        }
        else if (rb.linearVelocity.y > 0.001f && !Climb.isClimbing)
        {
            jumpAnimation.SetActive(true);
            idleAnimation.SetActive(false);
            idleAnimation2.SetActive(false);
            idleAnimation3.SetActive(false);
            idleAnimation4.SetActive(false);
            runAnimation.SetActive(false);
            runAnimation2.SetActive(false);
            runAnimation3.SetActive(false);
            runAnimation4.SetActive(false);
            runAnimation5.SetActive(false);
            crouchAnimation.SetActive(false);
            fallAnimation.SetActive(false);
            climbAnimation.SetActive(false);
            climbAnimation2.SetActive(false);
            climbAnimation3.SetActive(false);
        }
        else if (rb.linearVelocity.y < -0.001f && !Climb.isClimbing)
        {
            // Player is falling
            fallAnimation.SetActive(true);
            idleAnimation.SetActive(false);
            idleAnimation2.SetActive(false);
            idleAnimation3.SetActive(false);
            idleAnimation4.SetActive(false);
            runAnimation.SetActive(false);
            runAnimation2.SetActive(false);
            runAnimation3.SetActive(false);
            runAnimation4.SetActive(false);
            runAnimation5.SetActive(false);
            jumpAnimation.SetActive(false);
            crouchAnimation.SetActive(false);
            climbAnimation.SetActive(false);
            climbAnimation2.SetActive(false);
            climbAnimation3.SetActive(false);
        }
        else if (Mathf.Abs(horizontalInput) > 0.01f && !Climb.isClimbing)
        {
            
            runAnimTimer += Time.deltaTime;
            if (runAnimTimer >= runAnimSpeed)
            {
                runAnimTimer = 0f;
                runAnimIndex = (runAnimIndex + 1) % runAnimations.Length; // loop through 0–4
            }

            // Disable all, then enable current run frame
            for (int i = 0; i < runAnimations.Length; i++)
            {
                runAnimations[i].SetActive(i == runAnimIndex);
            }
            
            

            idleAnimation.SetActive(false);
            idleAnimation2.SetActive(false);
            idleAnimation3.SetActive(false);
            idleAnimation4.SetActive(false);
            jumpAnimation.SetActive(false);
            fallAnimation.SetActive(false);
            crouchAnimation.SetActive(false);
            climbAnimation.SetActive(false);
            climbAnimation2.SetActive(false);
            climbAnimation3.SetActive(false);

        }
        else if (Climb.isClimbing)
        {
        if (Mathf.Abs(rb.linearVelocity.y) > 0.01f) // moving up or down
        {
            climbAnimTimer += Time.deltaTime;
            if (climbAnimTimer >= climbAnimSpeed)
            {
                climbAnimTimer = 0f;
                climbAnimIndex = (climbAnimIndex + 1) % climbAnimations.Length; // loop frames
            }

            // Enable only the current frame
            for (int i = 0; i < climbAnimations.Length; i++)
            {
                climbAnimations[i].SetActive(i == climbAnimIndex);
            }
        }
        else
        {
            // Not moving: show idle climbing frame
            for (int i = 0; i < climbAnimations.Length; i++)
            {
                climbAnimations[i].SetActive(i == 0); 
            }

            //climbAnimation.SetActive(true); // single idle frame
        }
            idleAnimation.SetActive(false);
            idleAnimation2.SetActive(false);
            idleAnimation3.SetActive(false);
            idleAnimation4.SetActive(false);
            runAnimation.SetActive(false);
            runAnimation2.SetActive(false);
            runAnimation3.SetActive(false);
            runAnimation4.SetActive(false);
            runAnimation5.SetActive(false);
            runAnimation6.SetActive(false);
            jumpAnimation.SetActive(false);
            fallAnimation.SetActive(false);
            crouchAnimation.SetActive(false);


        }
        else
        {
            idleAnimTimer += Time.deltaTime;
            if (idleAnimTimer >= idleAnimSpeed)
            {
                idleAnimTimer = 0f;
                idleAnimIndex = (idleAnimIndex + 1) % idleAnimations.Length; // loop through 0–3
            }
            for (int i = 0; i < idleAnimations.Length; i++)
            {
                idleAnimations[i].SetActive(i == idleAnimIndex);
            }
            runAnimation.SetActive(false);
            runAnimation2.SetActive(false);
            runAnimation3.SetActive(false);
            runAnimation4.SetActive(false);
            runAnimation5.SetActive(false);
            runAnimation6.SetActive(false);
            jumpAnimation.SetActive(false);
            fallAnimation.SetActive(false);
            crouchAnimation.SetActive(false);
            climbAnimation.SetActive(false);
            climbAnimation2.SetActive(false);
            climbAnimation3.SetActive(false);
        }
}


    void FixedUpdate()
    {
        // Smooth acceleration / deceleration
        if (Mathf.Abs(targetSpeed) > 0.01f)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.fixedDeltaTime);
        }
        else
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
        }

        // Apply velocity
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cherry"))
        {
            cherries++;
            collectionLabel.text = "Cherries Left: " + cherries + "/" + total;
        }
    }
    
}
