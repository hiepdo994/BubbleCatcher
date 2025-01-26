using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera Camera;
    private Rigidbody2D rb;

    public float force;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            rb.isKinematic = true;
            transform.SetParent(collision.transform);
            transform.localScale = new Vector3(40f, 40f, 40f);
            rb.velocity = Vector2.zero;
            transform.position = collision.gameObject.transform.position;

            if (collision.gameObject.TryGetComponent<EnemyAI_1>(out EnemyAI_1 enemyComponent))
            {
                enemyComponent.Hit();
                
            }
            
        }
    }
}
