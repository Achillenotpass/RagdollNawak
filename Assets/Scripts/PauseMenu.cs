using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject m_ScreenPause = null;

    bool m_IsPauseDisplay = false;

    CatchArea m_CatchArea = null;

    private void Start()
    {
        Time.timeScale = 1;

        m_CatchArea = FindObjectOfType<CatchArea>();
    }

    private void Update()
    {
        if (!m_CatchArea.IsGameEnding)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!m_IsPauseDisplay)
                {
                    PauseGame();
                }
                else if (m_IsPauseDisplay)
                {
                    ResumeGame();
                }
            }
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        m_ScreenPause.SetActive(true);
        m_IsPauseDisplay = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        m_ScreenPause.SetActive(false);
        m_IsPauseDisplay = false;
    }

    public void ReloadGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        m_ScreenPause.SetActive(false);
        m_IsPauseDisplay = false;
        SceneManager.LoadScene("MainMenu");
    }

    public bool IsPauseDisplay
    {
        get
        {
            return m_IsPauseDisplay;
        }
    }
}
