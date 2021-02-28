using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    // Variable that holds the amount of points the player currently has.
    private int points = 0;

    // Reference to the Text object which is used to display the points on the screen.
    private Text pointsTextUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get the reference to the Text component.
        pointsTextUI = GetComponent<Text>();

        // Set the inital text.
        UpdateText(points);
    }

    public void UpdatePoints(int changeInPoints)
    {
        // Add the change to the variable.
        points += changeInPoints;

        // Update the display.
        UpdateText(points);
    }

    private void UpdateText(int newPoints)
    {
        pointsTextUI.text = $"Points: {newPoints}";
    }
}
