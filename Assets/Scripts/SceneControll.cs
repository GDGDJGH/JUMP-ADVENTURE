using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControll : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu2();
        }
    }



    public void LoadFirstLevel()
    {
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
        SceneManager.LoadScene(5);
        
    }

    public void LoadMainMenu()
    {
        FindObjectOfType<CoinPickUpManager>().resetScore();
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
        SceneManager.LoadScene(0);
        
    }

    public void LoadMainMenu2() {
        SceneManager.LoadScene(0);
    }

    public void LoadControll()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void PlayAgain() {
        FindObjectOfType<CoinPickUpManager>().resetScore();
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
        SceneManager.LoadScene(5);
    }

    public void Levels() {
        SceneManager.LoadScene(4);
    }
}