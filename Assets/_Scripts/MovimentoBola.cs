using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float baseSpeed = 5.0f;

    private Rigidbody2D rb2d;
    
    private bool gameStarted = false;
    public Transform ballDefaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Get the components rigid body.
        rb2d = GetComponent<Rigidbody2D>();

        // Set the components initial speed.
        Vector2 speed = rb2d.velocity;
        speed.x = -baseSpeed;
        speed.y = baseSpeed;
        rb2d.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted) {
            gameStarted = true;
            transform.position = ballDefaultPosition.position;
        }
    }
}
