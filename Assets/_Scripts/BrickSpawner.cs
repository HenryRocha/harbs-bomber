using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    // Reference to the Brick prefab.
    [SerializeField]
    private GameObject BrickPrefab;

    // Reference to the PointsUI class.
    [SerializeField]
    private PointsUI pointsUI;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 6; j++)
            {
                // Create a new brick, based on the BrickPrefab.
                Vector3 position = new Vector3(-8.8f + 1.6f * i, 0 + 0.6f * j);
                GameObject newBrick = Instantiate(BrickPrefab, position, Quaternion.identity, transform);

                // Pass the reference to the new brick.
                newBrick.GetComponent<BrickLogic>().pointsUI = pointsUI;

                // Change the hitpoints for the new brick depending on which line it is at.
                if (j == 6) newBrick.GetComponent<BrickLogic>().hitpoints = 9;
                else newBrick.GetComponent<BrickLogic>().hitpoints = j * 2 - 1;
            }
        }
    }
}
