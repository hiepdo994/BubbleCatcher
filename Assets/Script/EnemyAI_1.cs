using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1 : MonoBehaviour
{
    public float speed;
    public GameObject groundCheck;
    public LayerMask groundLayer;

    public bool facingRight;
    public bool grounded;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * speed * Time.deltaTime;
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, .2f, groundLayer);
        if (!grounded && facingRight)
        {
            Flip();
        }
        else if (!grounded && !facingRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        speed = -speed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, .2f);
    }
}
