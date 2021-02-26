using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void PauseGame()
    {
        pausePanelUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;

    }

    public void ResumeGame()
    {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void QuitToMainMenu()
    {
        pausePanelUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");
    }
}
