using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(string p_LevelName)
    {
        SceneManager.LoadScene(p_LevelName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
