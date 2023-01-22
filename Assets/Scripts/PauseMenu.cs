using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    [SerializeField] GameObject pauseMenu;
    bool isPaused = false;

    public void Pause() {
        SetIsPaused(true);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void Resume() {
        SetIsPaused(false);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameSession>().ResetGameSession();
        SceneManager.LoadScene(0);
    
    }

    public void Levels() { 
    
    }

    public void SetIsPaused(bool isPaused) {
        this.isPaused = isPaused;
    }

    public bool GetIsPaused() {
        return isPaused;
    }
}
