using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float swimSpeed = 2.5f;
    [SerializeField] Vector2 deathKick = new Vector2 (10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    [SerializeField] ArrowsPickUpManager arrowManager;

    Bullet arrow;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;

    bool isAlive = true;
    bool hasBow = false;
    bool hasKey = false;
    bool hasTarget = false;
    bool isLookingRight = true;
    bool hasElixir = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
        arrow = FindObjectOfType<Bullet>();

    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
        Swim();
        TouchingLava();
        
    }

    public void SetHasBow(bool hasBow) {
        this.hasBow = hasBow;
        
    }

    public void SetHasKey(bool hasKey)
    {
        this.hasKey = hasKey;
    }

    public void SetHasTarget(bool hasTarget)
    {
        this.hasTarget = hasTarget;
    }

    public bool GetHasTarget()
    {
        return this.hasTarget;
    }

    public bool GetHasKey() {
        return this.hasKey;
    }

    public void SetHasElixir(bool hasElixir)
    {
        this.hasElixir = hasElixir;
    }

    public bool GetHasElixir()
    {
        return this.hasElixir;
    }
    void OnFire(InputValue value)
    {        
        if (!isAlive || hasBow == false || FindObjectOfType<ArrowsPickUpManager>().GetArrows() <= 0 || FindObjectOfType<PauseMenu>().GetIsPaused() == true) { return; }
            FindObjectOfType<ArrowsPickUpManager>().updateArrows();
            float playerRotation = Mathf.Sign(myRigidbody.velocity.x);
            Instantiate(bullet, gun.position, transform.rotation);   
    }
    public bool GetPlayerRotation(){
        if(transform.localScale.x == -1)
        {
            isLookingRight = false;
        }
        else
        {
            isLookingRight = true;
        }
        return isLookingRight;
    }
    
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return;}
        
        if(value.isPressed)
        {            
            myRigidbody.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2 (Mathf.Sign(myRigidbody.velocity.x), 1f);           
        }
    }

    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))) 
        { 
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }
        
        Vector2 climbVelocity = new Vector2 (myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
        
    }
    void Swim()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Water1")))
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * swimSpeed, moveInput.y * swimSpeed);
            myRigidbody.velocity = playerVelocity;   
        }
    }

    public void Die()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            FindObjectOfType<ArrowsPickUpManager>().resetArrows();
            myAnimator.SetTrigger("Dying");
            myRigidbody.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    public void OtherDie() {
        isAlive = false;
        FindObjectOfType<ArrowsPickUpManager>().resetArrows();
        myAnimator.SetTrigger("Dying");
        myRigidbody.velocity = deathKick;
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }

    void TouchingLava() {
        if (hasElixir == true) {
            if (myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Lava")))
            {
                Vector2 playerVelocity = new Vector2(moveInput.x * swimSpeed, moveInput.y * swimSpeed);
                myRigidbody.velocity = playerVelocity;
            }
            return;
        }
        else if(myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Lava"))){
            OtherDie();
        }
    }

    public bool GetAlive() {
        return isAlive;
    }

    public void SetSpeed(float speed) {
        this.runSpeed = speed;
    }

}
