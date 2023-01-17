using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuiverPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int ArrowsForArrowPickup = 3;
    [SerializeField] ArrowsSO arrows;
    bool wasCollected = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !wasCollected)
        {

            wasCollected = true;
            arrows.AddToArrows(ArrowsForArrowPickup);         
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

  
}
