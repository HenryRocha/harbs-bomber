using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pausePanelUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pressed ESC!");

            if (GameIsPaused)
            {
                Debug.Log("Paused!");
                ResumeGame();
            }
            else
            {
                Debug.Log("Continued!");
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        pausePanelUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;

    }

    void ResumeGame()
    {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
}
