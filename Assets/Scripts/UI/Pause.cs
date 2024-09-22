using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool ispaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        ispaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            togglePause();
        }
    }
    public void OnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }
    public void OnResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }
    public void togglePause()
    {
        if(ispaused == true)
        {
            OnResume();
        }
        else
        {
            OnPause();
        }
    }
    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
