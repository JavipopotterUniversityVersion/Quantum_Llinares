using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    
    public void Pause()
    {
       
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0.0f) Resume();
        else Pause();
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Game restarted.");
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
