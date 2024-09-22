using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.GameMusic);
        AudioManager.Instance.PlaySFXoneshot(AudioManager.Instance.MenuSFX, 0);
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OnResumePress()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
