using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 20f;
    Rigidbody2D myRigidbody;
    PlayerMovement player;
    float xSpeed;
    public SpriteRenderer ArrowRotation;
    
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        xSpeed = player.transform.localScale.x * bulletSpeed;
        ArrowRotation = GetComponent<SpriteRenderer>();
        
        
        
    }

    void Update()
    {
       
        myRigidbody.velocity = new Vector2 (xSpeed, 0f);
        if(Input.GetKeyDown(KeyCode.A)){
            ArrowRotation.flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.D)){
            ArrowRotation.flipX = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);    
    }

    public void flipArrow(){
        ArrowRotation.flipX = true;
    }
}
