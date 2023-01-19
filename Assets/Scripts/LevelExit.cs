using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] GameObject Key;
    [SerializeField] Color32 keyIsExist = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 keyIsNotExist = new Color32(1, 1, 1, 1);
    SpriteRenderer spriteRenderer;
    [SerializeField] GameObject Target;
    

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (Key || Target) {
            spriteRenderer.color = keyIsExist;
        }
    }

    private void Update()
    {
        if (FindObjectOfType<PlayerMovement>().GetHasKey() ) {
            spriteRenderer.color = keyIsNotExist;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (Key || Target)
        {            
            if (FindObjectOfType<PlayerMovement>().GetHasKey())
            {
                if (other.tag == "Player")
                {
                    StartCoroutine(LoadNextLevel());
                }
            }
        }
        else
        {
            if (other.tag == "Player")
            {
                StartCoroutine(LoadNextLevel());
            }
        }  
        
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            FindObjectOfType<GameSession>().ResetGameSession();
            nextSceneIndex = 3;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
