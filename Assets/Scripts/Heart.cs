using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    bool wasCollected = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            gameObject.SetActive(false);
            FindObjectOfType<GameSession>().AddLife();
            Destroy(gameObject);
            
        }
    }
}
