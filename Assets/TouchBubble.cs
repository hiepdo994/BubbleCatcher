using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBubble : MonoBehaviour
{
    public float bubbleSize = 10f;
    public float scaleFactor = 1.2f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bubbles"))
        {
            float currentScale = transform.localScale.x;
            float colliderScale = collision.gameObject.transform.localScale.x;
            if (currentScale > colliderScale)
            {
                transform.localScale *= scaleFactor;
                Debug.Log("Object is growing yes ");
                Destroy(collision.gameObject);
            }
            else if(currentScale < colliderScale )
            {
                collision.gameObject.transform.localScale *= scaleFactor;
                Debug.Log("Object is growing no");
                Destroy(gameObject);
            }
            else if(currentScale == colliderScale)
            {
                Destroy(gameObject);
                Debug.Log("idk");
            }
        }
    }
}
