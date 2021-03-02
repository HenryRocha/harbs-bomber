using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{
    // Add slider on Unity's UI.
    [Range(1, 10)]
    public float speed = 8.0f;

    // Variables to help prevent the paddle from going off-screen.
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        // Get the screen boundaries.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        // Get the components dimensions.
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Get the current direction.
        float inputX = Input.GetAxis("Horizontal");
        
        // Get the current position.
        Vector3 currentPos = transform.position;

        // Calculate the new X position.
        // If it goes outside the screen boundaries, clamp it.
        // https://docs.unity3d.com/ScriptReference/Mathf.Clamp.html
        currentPos.x = Mathf.Clamp(currentPos.x + inputX * Time.deltaTime * speed, - screenBounds.x + objectWidth, screenBounds.x - objectWidth);

        // Replace the current position with the new one.
        transform.position = currentPos;
    }
}
