using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerScript : MonoBehaviour
{
    public Color newColor = Color.red; // Change this to the desired color

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        // Access the SpriteRenderer component of the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Renderer component not found on the object.");
        }
    }

    private void Update()
    {
        // Check for a user input (e.g., pressing a key)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeObjectColor(newColor);
        }
    }

    // Function to change the color of the object
    private void ChangeObjectColor(Color color)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color; // Use "spriteRenderer.color" to change the sprite color
        }
    }
}