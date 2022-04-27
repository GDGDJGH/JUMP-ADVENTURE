using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            FindObjectOfType<PlayerMovement>().SetHasBow(true);
            Destroy(gameObject);
        }
    }
}
