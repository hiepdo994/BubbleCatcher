using UnityEngine;
using TMPro;

public class starCollect : MonoBehaviour
{
    public TMP_Text starText; // Reference to the TextMeshPro text component

    void Start()
    {
        if (starText == null)
        {
            Debug.LogError("Star Text is not assigned in the Inspector!");
        }
    }

    public void AddStar()
    {
        if (starText != null)
        {
            // Get the current text
            string currentText = starText.text;

            // Convert the text to an integer
            if (int.TryParse(currentText, out int currentStars))
            {
                // Increment the value
                currentStars += 1;

                // Update the text with the new value
                starText.text = currentStars.ToString();
                Debug.Log("Star count updated to: " + currentStars);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Failed to parse starText to an integer. Current text: " + currentText);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AddStar();
        }
    }
}
