using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float direction;
    private bool hit;
    public Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hit) { return; }
        float movementSpeed = force * Time.deltaTime * direction;
        transform.Translate(movementSpeed , 0 ,0 ); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hit = true;

            if (collision.gameObject.TryGetComponent<EnemyAI_1>(out EnemyAI_1 enemyComponent))
            {
                enemyComponent.Hit();
                
            }
            
        }
    }

    public void SetDirection(float _direction)
    {
        gameObject.SetActive(true);
        hit = false;
        direction = _direction;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
