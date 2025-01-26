using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement variable
    public float horizontal;
    public float speed = 8f;
    public float jump = 16f;
    public bool facingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //knock back force variable 
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // character movement if knock back counter detected then do else and add force
    // to knock back player movement
    void Update()
    {
        if (KBCounter <= 0)
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                Animator.SetBool("Jump", true);
            }
            else Animator.SetBool("Jump", false);

            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
                Animator.SetBool("Jump", true);
            }
            else Animator.SetBool("Jump", false);
            Flip();
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        if (horizontal == 0)
        {
            Animator.SetInteger("Velocity", 0);

        }
        if (horizontal == 1 || horizontal < 0)
        {
            Animator.SetInteger("Velocity", 1);
        }

    }

    private void Flip()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            gameObject.transform.localScale = new Vector3(horizontal, 1, 1);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, .2f, groundLayer);
    }
}
