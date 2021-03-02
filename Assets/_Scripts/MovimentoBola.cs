using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    // Base speed.
    [Range(1, 15)]
    public float baseSpeed = 500.0f;

    // Reference to this object's Rigid Body 2D.
    private Rigidbody2D rb2d;
    
    // If the game has started or not.
    private bool gameStarted = false;

    // Reference to the ball's default position above the paddle.
    public Transform ballDefaultPosition;

    // Reference to the LivesUI class.
    public LivesUI livesUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get the components rigid body.
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (!gameStarted)
        {   
            transform.position = ballDefaultPosition.position;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted) {
            gameStarted = true;
            rb2d.AddForce(Vector2.up * baseSpeed);
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "BottomWall")
        {
            gameStarted = false;
            rb2d.velocity = Vector2.zero;
            livesUI.UpdateLives(-1);
        }
    }
}
