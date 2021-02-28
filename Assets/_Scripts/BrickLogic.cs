using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickLogic : MonoBehaviour
{
    // Reference to the PointsUI class.
    public PointsUI pointsUI;

    // Reference to the Sprite Rendender, to enable sprite changing through scripts.
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    // List of sprites.
    [SerializeField]
    private Sprite[] sprites = new Sprite[10];

    // Amount of hitpoints the brick has by default.
    public int hitpoints = 1;

    // Variable to store the starting amount of hitpoints.
    public int startingHitpoints;


    [SerializeField]
    private AudioSource audioSource;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        spriteRenderer.sprite = sprites[hitpoints];
        startingHitpoints = hitpoints;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {

    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        hitpoints -= 1;
        pointsUI.UpdatePoints(+20);

        if (hitpoints < 0)
        {
            pointsUI.UpdatePoints(+100 * startingHitpoints);
            audioSource.Play();
            Destroy(this.gameObject, audioSource.clip.length);
        }
        else
        {
            spriteRenderer.sprite = sprites[hitpoints];
        }
    }
}
