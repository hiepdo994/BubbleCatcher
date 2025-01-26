using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_1 : MonoBehaviour
{
    public GameObject bubble;
    public bool canMove;
    public float speed;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public Transform player;
    public Animator animator;

    public bool facingRight = true;
    public bool grounded;
    private Rigidbody2D rb;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private CapsuleCollider2D BoxCollider2D;
    [SerializeField] private LayerMask playerLayer;
    private float coolDownTimer = Mathf.Infinity;

    public float airTime;
    public float freq;
    public float amp;

    private float flipCooldown = 0.5f; // Delay to prevent constant flipping
    private float lastFlipTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        lastFlipTime = Time.time; // Initialize flip timer
    }

    // Update is called once per frame
    void Update()
    {
        // Check if grounded
        grounded = Physics2D.OverlapCircle(groundCheck.transform.position, .2f, groundLayer);

        if (canMove && grounded)
        {
            Move();
        }
        else
        {
            // Stop horizontal movement when not grounded
            rb.velocity = new Vector2(0, rb.velocity.y);

            // Add vertical oscillation (if necessary)
            if (!canMove)
            {
                transform.position = new Vector2(transform.position.x, Mathf.Sin(Time.time * freq) * amp + airTime);
            }
        }
    }

    void Move()
    {
        // Set velocity
        rb.velocity = new Vector2((facingRight ? 1 : -1) * speed * Time.deltaTime, rb.velocity.y);

        // Flip if needed and cooldown has elapsed
        if (!grounded && Time.time > lastFlipTime + flipCooldown)
        {
            Flip();
        }
        if (Wall())
        {
            Flip();
        }

    }

    private bool Wall()
    {
        RaycastHit2D hit = Physics2D.BoxCast(BoxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(BoxCollider2D.bounds.size.x * range, BoxCollider2D.bounds.size.y, BoxCollider2D.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    public void Hit()
    {
        bubble.SetActive(true);
        canMove = false;
        animator.SetBool("Hit", true);
    }

    void Flip()
    {
        // Flip direction
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        lastFlipTime = Time.time; // Update the flip cooldown timer
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider2D.bounds.center + transform.right * range * transform.lossyScale.x * colliderDistance,
            new Vector3(BoxCollider2D.bounds.size.x * range, BoxCollider2D.bounds.size.y, BoxCollider2D.bounds.size.z));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, .2f);
    }
}


/*
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
        bubble.SetActive(true);
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
*/