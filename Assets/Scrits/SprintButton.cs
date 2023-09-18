using UnityEngine;
using UnityEngine.UI;

public class GrayOutUI : MonoBehaviour
{
    private Image uiImage;
    private Color originalColor;
    private bool isGrayedOut = false;

    private void Start()
    {
        // Get the Image component attached to the UI element.
        uiImage = GetComponent<Image>();

        // Store the original color of the UI graphic.
        originalColor = uiImage.color;
    }

    private void Update()
    {
        // Check if the left shift key is pressed.
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            // If the UI element is not already grayed out, gray it out.
            if (!isGrayedOut)
            {
                uiImage.color = Color.gray;
                isGrayedOut = true;

                // Start a coroutine to return it to the original color after 5 seconds.
                StartCoroutine(RevertToOriginalColor());
            }
        }
    }

    private System.Collections.IEnumerator RevertToOriginalColor()
    {
        // Wait for 5 seconds.
        yield return new WaitForSeconds(8f);

        // Set the UI element's color back to the original color.
        uiImage.color = originalColor;
        isGrayedOut = false;
    }
}