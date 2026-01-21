using System.Collections;
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
    private bool attacking;

    private Animator animator;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        //playerAttackBox.OnPogoAttack += GetEnemyPoints;
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("!!!!");
            Attack();
        }

        SetAnimation(moveInput);
        
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, grounCheckRadius, groundLayer);
    }

    private void SetAnimation(float moveInput)
    {
        if (!attacking)
        {
            if (isGrounded)
            {
                if (moveInput == 0)
                {
                    animator.Play("Idle");
                }
                else if (rb.linearVelocityX > 0)
                {
                    sr.flipX = false;
                    animator.Play("Run");
                }
                else if (rb.linearVelocityX < 0)
                {
                    sr.flipX = true;
                    animator.Play("Run");
                }

            }
            else
            {
                if (rb.linearVelocityY > 0)
                {
                    if (rb.linearVelocityX >= 0)
                    {
                        sr.flipX = false;
                        animator.Play("Jump");
                    }
                    else if (rb.linearVelocityX <= 0)
                    {
                        sr.flipX = true;
                        animator.Play("Jump");
                    }
                }
                else if (rb.linearVelocityY <= 0)
                {
                    if (rb.linearVelocityX >= 0)
                    {
                        sr.flipX = false;
                        animator.Play("Fall");
                    }
                    else if (rb.linearVelocityX <= 0)
                    {
                        sr.flipX = true;
                        animator.Play("Fall");
                    }
                }
                else if (true)
                {

                }
            }
        }
    }

    private IEnumerator Attack()
    {
        
        Debug.Log("AAAAAAH");
        attacking = true;
        animator.Play("Slash");
        yield return new WaitForSeconds(0.25f);
        attacking = false;
        Debug.Log("Done Attacking");
    }

}
