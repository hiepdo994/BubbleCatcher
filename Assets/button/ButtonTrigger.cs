using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Sprite newSprite; 
    public Sprite originalSprite; 
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        // Get the SpriteRenderer component on this object
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Ensure originalSprite is set to the current sprite if not manually assigned
        if (originalSprite == null && spriteRenderer != null)
        {
            Debug.Log("there's renderer");
            originalSprite = spriteRenderer.sprite;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collision happen");
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("bubbles"))
        {
            // Swap the sprite to the new sprite
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }
    
    private void OnTriggerHold2D(Collider2D collision)
    {
        Debug.Log("collision happen");
        if (collision.gameObject.CompareTag("Player")||collision.gameObject.CompareTag("bubbles"))
        {
            // Swap the sprite to the new sprite
            if (spriteRenderer != null && newSprite != null)
            {
                spriteRenderer.sprite = newSprite;
            }
        }
    }

    private void OntriggerExit2D(Collision2D collision)
    {
        // Optional: Reset to the original sprite when the player steps off
        if (collision.gameObject.CompareTag("Player"))
        {
            if (spriteRenderer != null && originalSprite != null)
            {
                spriteRenderer.sprite = originalSprite;
            }
        }
    }
}
