using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TouchBubble : MonoBehaviour
{
   private Vector3 mousePos;
    private Camera camera;
    public float bubbleSize = 10f;
    public float scaleFactor = 2f;
    public Rigidbody2D rb;
    public float floatForce = 10;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        camera = Camera.main;
         


        //rb.velocity = transform.right * floatForce;
    }

    // Update is called once per frame
    void Update()
    {


        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - transform.position).normalized;
        rb.AddForce(direction * floatForce);

        //rb.AddForce(Vector3.right * floatForce, ForceMode2D.Force);

        /*Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * floatForce;
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bubbles"))
        {
            float currentScale = transform.localScale.x;
            float colliderScale = collision.gameObject.transform.localScale.x;
            if (currentScale > colliderScale)
            {
                gameObject.transform.localScale *= scaleFactor;
                Debug.Log("Object is growing yes ");
            }
        }
    }
}
