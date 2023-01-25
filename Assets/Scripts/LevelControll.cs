using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControll : MonoBehaviour
{
    

    public void Level1() {
        SceneManager.LoadScene(5);
    }
    public void Level2()
    {
        SceneManager.LoadScene(6);
    }
    public void Level3()
    {
        SceneManager.LoadScene(7);
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
    }
    public void Level4()
    {
        SceneManager.LoadScene(8);
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
    }
    public void Level5()
    {
        SceneManager.LoadScene(9);
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
    }
    public void Level6()
    {
        SceneManager.LoadScene(10);
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
    }
    public void Level7()
    {
        SceneManager.LoadScene(11);
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
    }

    public void Levels() {
        Time.timeScale = 1f;
        
        FindObjectOfType<GameSession>().ResetGameSession();
        
        SceneManager.LoadScene(4);
        
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        FindObjectOfType<GameSession>().ResetGameSession();
        SceneManager.LoadScene(0);

    }

}
