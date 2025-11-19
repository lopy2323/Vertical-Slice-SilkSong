using UnityEngine;

public class SimplePlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;

    [Header("Jump")]
    public float jumpForce = 12f;
    public float maxJumpTime = 0.25f;   // Hoe lang je jump kunt vasthouden
    public float coyoteTime = 0.15f;    // Tijd na verlaten grond dat je nog kunt springen
    public float jumpBufferTime = 0.1f; // Tijd dat jump input onthouden wordt

    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;

    // Jump variables
    private bool isJumping = false;
    private float jumpTimeCounter = 0f;
    private float coyoteCounter = 0f;
    private float jumpBufferCounter = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // ---- HORIZONTALE BEWEGING ----
        float moveInput = Input.GetAxisRaw("Horizontal"); // -1 (links) / 0 / 1 (rechts)
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // ---- GROUND CHECK ----
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // ---- COYOTE TIME ----
        if (isGrounded)
            coyoteCounter = coyoteTime;
        else
            coyoteCounter -= Time.deltaTime;

        // ---- JUMP BUFFER ----
        if (Input.GetKeyDown("w"))
            jumpBufferCounter = jumpBufferTime;
        else
            jumpBufferCounter -= Time.deltaTime;

        // ---- START JUMP ----
        if (jumpBufferCounter > 0f && coyoteCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // eerste impulse
            isJumping = true;
            jumpTimeCounter = maxJumpTime;
            jumpBufferCounter = 0f; // reset buffer
        }

        // ---- VARIABLE JUMP HEIGHT ----
        if (Input.GetKey("w") && isJumping)
        {
            if (jumpTimeCounter > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // houd jump
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        // ---- EIND JUMP ALS JE LOSLAAT ----
        if (Input.GetKeyUp("w"))
        {
            isJumping = false;
        }

        // ---- STOP HORIZONTALE GLIJDING ----
        if (moveInput == 0f)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y); // stop horizontaal direct
        }
    }

    // ---- VISUALIZE GROUND CHECK ----
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
