using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            FindObjectOfType<PlayerMovement>().SetHasBow(true);
            Destroy(gameObject);
            
        }
    }

    private void Update()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex >= 6) {
            FindObjectOfType<PlayerMovement>().SetHasBow(true);
        }
    }

}
