using UnityEngine;
using UnityEngine.SceneManagement;
public class doorNextStage : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load
    private bool isPlayerNear;   // Tracks if the player is near the door

    void Start()
    {
        isPlayerNear = false; // Ensure the initial state is false
    }

    void Update()
    {
        // Check if the player is near and presses the E key
        if (isPlayerNear && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Player triggered the door. Loading next stage...");
            LoadNextStage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect when the player enters the door's trigger area
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Player is near the door.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Detect when the player leaves the door's trigger area
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerNear = false;
            Debug.Log("Player left the door.");
        }
    }

    void LoadNextStage()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            Debug.Log(nextSceneName);
            // Load the next scene (requires Unity's Scene Management)
           SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("Next scene name is not set!");
        }
    }
}
