using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    

    [SerializeField] TextMeshProUGUI livesText;
    
    
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start() 
    {
        livesText.text = playerLives.ToString();       
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            SceneManager.LoadScene(3);           
            ResetGameSession();
        }
    }

    void TakeLife()
    {
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    public void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        Destroy(gameObject);    
    }

    public void AddLife() {
        playerLives++;
        livesText.text = playerLives.ToString();
    }
}
