using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    public GameObject uiCanvas;
    public GameObject pauseMenu;
    public void Initialize()
    { 
        uiCanvas.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.P))
        {
            OnPausePress();
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
    }
    public void OnResumePress()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitOutTheGame()
    {
        Application.Quit();
    }
}
