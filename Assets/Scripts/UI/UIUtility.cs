using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    public GameObject uiCanvas;
    public GameObject pauseMenu;
    private bool isPaused;
    public void Initialize()
    { 
        uiCanvas.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
    }
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.P) && isPaused == false)
        {
            OnPausePress();
        }
        else if (Input.GetKeyUp(KeyCode.P) && isPaused == true)
        {
            OnResumePress();
        }

    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPausePress()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void QuitOutTheGame()
    {
        Application.Quit();
    }
}
