using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    bool wasCollected = false;
    [SerializeField] float timeToAdd;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            gameObject.SetActive(false);
            FindObjectOfType<Timer>().SetTimer(timeToAdd);
            Destroy(gameObject);

        }
    }
}
