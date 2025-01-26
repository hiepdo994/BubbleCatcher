using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1 : MonoBehaviour
{
    public bool canMove;
    public float speed;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public Transform player;
    public Animator animator;

    public bool facingRight;
    public bool grounded;
    private Rigidbody2D rb;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private CapsuleCollider2D BoxCollider2D;
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity;

    public float freq;
    public float amp;

    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
        else
        {
            rb.velocity = Vector2.zero;
            transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * freq) * amp + 5f);
        }


    }
    public void Hit()
    {
        canMove = false;
        animator.SetBool("Hit", true);
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider2D.bounds.center + transform.right * range * transform.lossyScale.x * colliderDistance, new Vector3(BoxCollider2D.bounds.size.x * range, BoxCollider2D.bounds.size.y, BoxCollider2D.bounds.size.z));
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
