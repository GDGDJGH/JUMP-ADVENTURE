using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour
{
    bool wasCollected = false;
    [SerializeField] float runSpeed = 20f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            gameObject.SetActive(false);
            FindObjectOfType<PlayerMovement>().SetSpeed(runSpeed);
            Destroy(gameObject);

        }
    }
}
