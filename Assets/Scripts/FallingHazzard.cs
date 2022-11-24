using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingHazzard : MonoBehaviour
{
    Rigidbody2D myRigidbody;
    CapsuleCollider2D myCapsuleCollider;
    BoxCollider2D myBoxCollider;
    [SerializeField] float gravity = 1f;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();     
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerWithFloor();
        OnTriggerWithPlayer();
    }

    private void OnTriggerWithFloor()
    {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))){
                Destroy(gameObject);
                {
                
            }
        }
    }

    private void OnTriggerWithPlayer() {
        if (myBoxCollider.IsTouchingLayers(LayerMask.GetMask("Player"))){
            Debug.Log("Spadl osten");
            FindObjectOfType<PlayerMovement>().OtherDie();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        myRigidbody.gravityScale = gravity;
    }






}
