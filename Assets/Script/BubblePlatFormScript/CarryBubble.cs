using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryBubble : MonoBehaviour
{
    public Transform holdPoint; // The point where the bubble will be held
    public float grabRange = 2f; // The range within which the player can grab the bubble
    public LayerMask bubbleLayer; // Layer mask to identify bubbles
    public KeyCode grabKey = KeyCode.E; // Key to grab/release the bubble

    private GameObject grabbedBubble; // The currently held bubble

    void Update()
    {
        if (Input.GetKeyDown(grabKey))
        {
            if (grabbedBubble == null)
            {
                // Try to grab a bubble
                Debug.Log("TRY");
                TryGrabBubble();
            }
            else
            {
                // Release the bubble
                ReleaseBubble();
            }
        }

        // If holding a bubble, keep it at the hold point
        if (grabbedBubble != null)
        {
            grabbedBubble.transform.position = holdPoint.position;
        }
    }

    void TryGrabBubble()
    {
        // Check for nearby bubbles within range
        Collider2D bubble = Physics2D.OverlapCircle(transform.position, grabRange, bubbleLayer);
        if (bubble != null)
        {
            grabbedBubble = bubble.gameObject;
            grabbedBubble.GetComponent<Rigidbody2D>().isKinematic = true; // Stop physics simulation
        }
    }

    void ReleaseBubble()
    {
        if (grabbedBubble != null)
        {
            grabbedBubble.GetComponent<Rigidbody2D>().isKinematic = false; // Re-enable physics simulation
            grabbedBubble = null;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the grab range in the editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, grabRange);
    }
}
