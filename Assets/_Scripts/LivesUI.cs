using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesUI : MonoBehaviour
{
    // Variable that holds the amount of lives the player currently has.
    private int lives = 5;

    // Reference to the Text object, which is used to display the lives on the screen.
    private Text livesTextUI;

    // Start is called before the first frame update
    void Start()
    {
        // Get the reference to the Text component.
        livesTextUI = GetComponent<Text>();

        // Set the inital text.
        UpdateText(lives);
    }

    public void UpdateLives(int changeInLifes)
    {
        // Add the change to the variable.
        lives += changeInLifes;

        if (lives <= 0)
        {
            SceneManager.LoadScene("YouLose");
            return;
        }

        // Update the display.
        UpdateText(lives);
    }

    private void UpdateText(int newLives)
    {
        livesTextUI.text = $"Lives: {newLives}";
    }
}
