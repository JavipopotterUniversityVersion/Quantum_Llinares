using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;
    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Quit()
    {
        Debug.Log("Application closed.");
        Application.Quit();
    }
    public void Restart()
    {
        Time.timeScale = 1.0f;
        Debug.Log("Game restarted.");
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
