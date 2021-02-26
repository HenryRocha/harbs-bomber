using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float baseSpeed = 5.0f;

    private Rigidbody2D rb2d;
    
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        // Get the screen boundaries.
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        // Get the components dimensions.
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2

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
        Vector3 currentPos = transform.position;
        Vector2 speed = rb2d.velocity;
        
        // Right side
        if (currentPos.x > screenBounds.x - objectWidth) {
            speed.x = -baseSpeed;
        }

        // Left side
        if (currentPos.x < - screenBounds.x + objectWidth) {
            speed.x = baseSpeed;
        }

        // Top side
        if (currentPos.y > screenBounds.y - objectHeight) {
            speed.y = -baseSpeed;
        }

        // Bottom side
        if (currentPos.y < - screenBounds.y + objectHeight) {
            speed.x = 0;
            speed.y = 0;
            rb2d.velocity = speed;
            return;
        }

        rb2d.velocity = speed;
    }
}
