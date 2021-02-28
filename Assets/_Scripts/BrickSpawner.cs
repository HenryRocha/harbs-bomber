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
        for (int i = 1; i <= 9; i++)
        {
            for (int j = 1; j <= 5; j++)
            {
                Vector3 position = new Vector3(-8.5f + 1.7f * i, 0 + 0.8f * j);
                GameObject newBrick = Instantiate(BrickPrefab, position, Quaternion.identity, transform);
                newBrick.GetComponent<BrickLogic>().pointsUI = pointsUI;
                newBrick.GetComponent<BrickLogic>().hitpoints = j * 2 - 1;
            }
        }
    }
}
