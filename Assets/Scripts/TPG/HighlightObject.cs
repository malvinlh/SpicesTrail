using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    [Header("Highlight Settings")]
    public Color highlightColor = Color.red; // Color to highlight the object
    public float pulseSpeed = 2f;            // Speed of the pulsing effect

    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    private Color originalColor;            // Original color of the object
    private bool isHighlighted = false;     // Flag to toggle the highlight state

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("HighlightObject requires a SpriteRenderer component.");
            enabled = false;
            return;
        }

        // Store the original color
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // Apply the pulsing effect if highlighted
        if (isHighlighted)
        {
            float pulse = Mathf.PingPong(Time.time * pulseSpeed, 1);
            spriteRenderer.color = Color.Lerp(originalColor, highlightColor, pulse);
        }
    }

    // Public method to enable highlighting
    public void EnableHighlight()
    {
        isHighlighted = true;
    }

    // Public method to disable highlighting
    public void DisableHighlight()
    {
        isHighlighted = false;
        spriteRenderer.color = originalColor; // Reset to the original color
    }
}
