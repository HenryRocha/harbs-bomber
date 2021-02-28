using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float baseSpeed = 500.0f;

    private Rigidbody2D rb2d;
    
    private bool gameStarted = false;
    public Transform ballDefaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get the components rigid body.
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
        }
    }
}
