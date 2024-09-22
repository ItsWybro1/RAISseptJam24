using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    public GameObject uiCanvas;
    public void Initialize()
    { 
        uiCanvas.SetActive(true); 
        Time.timeScale = 1.0f;
    }
    public void Update()
    {

    }
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void QuitOutTheGame()
    {
        Application.Quit();
    }
}
