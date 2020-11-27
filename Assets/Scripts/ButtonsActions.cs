using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsActions : MonoBehaviour
{
    //Script to put on canvas to allow diverse actions by buttons

    public void ChangeScene(string p_NextScene)
    {
        SceneManager.LoadScene(p_NextScene);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
