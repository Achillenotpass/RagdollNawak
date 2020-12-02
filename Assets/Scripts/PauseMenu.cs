using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject screenPause;
    bool isPauseDisplay = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseDisplay)
            {
                PauseGame();
            }
            else if (isPauseDisplay)
            {
                ResumeGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        screenPause.SetActive(true);
        isPauseDisplay = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        screenPause.SetActive(false);
        isPauseDisplay = false;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        screenPause.SetActive(false);
        isPauseDisplay = false;
        SceneManager.LoadScene("MainMenu");
    }
}
