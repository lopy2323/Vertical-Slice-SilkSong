using UnityEngine;
using UnityEngine.EventSystems;

public class Hornet : MonoBehaviour
{
    
    [SerializeField] Transform groundCheck;
    [SerializeField] float grounCheckRadius;
    [SerializeField] LayerMask groundLayer;

    [SerializeField ]private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool isGrounded;
    private bool pogoAttack;

    private Animator animator;
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        SetAnimation(moveInput);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, grounCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (isGrounded)
        {
            animator.Play("Idle");
        } 
        else
        {
            if (rb.linearVelocityY > 0)
            {
                animator.Play("Jump");
            } 
            else if (rb.linearVelocityY < 0)
            {
                animator.Play("Fall");
            } 
            else if (true)
            {

            }
        }












        /*
        if (isGrounded)
        {
            if (moveInput == 0)
            {
                rb.linearVelocityX = 0f;
                animator.Play("Idle_(Temporary)");
            }
            else if (rb.linearVelocityX > 0)
            {
                sr.flipX = false;
                animator.Play("Run_(Temporary)");
            }
            else if (rb.linearVelocityX < 0)
            {
                sr.flipX = true;
                animator.Play("Run_(Temporary)");
            }
        }
        else
        {
            if (rb.linearVelocityY > 0)
            {
                 if (rb.linearVelocityX > 0)
                {
                    sr.flipX = false;
                    animator.Play("Jump_(Temporary)");
                }
                else if (rb.linearVelocityX < 0)
                {
                    sr.flipX = true;
                    animator.Play("Jump_(Temporary)");
                }
            }
            else if (rb.linearVelocityY <= 0)
            {
                if (rb.linearVelocityX > 0)
                {
                    sr.flipX = false;
                    animator.Play("Fall_(Temporary)");
                }
                else if (rb.linearVelocityX < 0)
                {
                    sr.flipX = true;
                    animator.Play("Fall_(Temporary)");
                }
            }
        }*/
    }

}
