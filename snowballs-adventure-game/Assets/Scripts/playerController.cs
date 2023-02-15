using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public enum playerStatus
    {
        onGround,
        inAir
    }
    public playerStatus currentStatus = playerStatus.onGround;
    //Contains all of the constants and variables relating to Left-Right movement
    [Header("Movement")]
    public float maxSpeed;

    //Contains constants and variables for jumping
    [Header("Jumping")]
    public float jumpPower;
    private float detectionHight = 1f;
    public LayerMask collisionGeometry;
    public float dampeningConstant;
    //Jump buffering
    private const float bufferTime = 1f;
    private float jumpBuffer = bufferTime;

    private Rigidbody2D rb;
    private Animator animator;
    private const float scaleX = 2;

    void Start()
    {
        //Standard retrieving Rigidbody
        rb = GetComponent<Rigidbody2D>();
        //Player Animator
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        var scale = transform.localScale;
        
        //Calculating required force to prevent going over maximum speed
        float runForce = rb.mass * ((maxSpeed - Mathf.Abs(rb.velocity.x)) /  (Time.deltaTime * 1000 ));

        //Left-Right Movement
        if (Input.GetKey("d"))
        {
            //Add force, update animation, update scale
            rb.AddForce(runForce * Vector2.right);
            transform.localScale = new Vector3(scaleX, scale.y);
            if (currentStatus == playerStatus.onGround)
            {
                animator.SetBool("isRunning", true);
            }
        }
        if (Input.GetKey("a"))
        {
            //Add force, update animation, update scale
            rb.AddForce(runForce * Vector2.left);
            transform.localScale = new Vector3(-scaleX, scale.y);
            if (currentStatus == playerStatus.onGround)
            {
                animator.SetBool("isRunning", true);
            }
        }

        //If not giving input, do not run
        if (Input.GetAxis("Horizontal") == 0)
        {
            if (currentStatus == playerStatus.onGround)
            {
                animator.SetBool("isRunning", false);
            }
            
        }
        
        //Jump if on ground
        if (Input.GetKeyDown("space") && currentStatus == playerStatus.onGround)
        {
            jump();
        }
        
        //Determining when on ground
        var groundDetection = Physics2D.Raycast(transform.position, Vector2.down, detectionHight, collisionGeometry);
        if (groundDetection.collider != null)
        {
            currentStatus = playerStatus.onGround;
            animator.SetBool("onGround", true);
        }
        else
        {
            currentStatus = playerStatus.inAir;
            animator.SetBool("onGround", false);
        }
        
        //Jump if the jump is buffered
        //If space is pressed and not on ground
        if (Input.GetKeyDown("space") && currentStatus == playerStatus.inAir)
        {
            //Set a timer
            jumpBuffer = bufferTime;
        }
        jumpBuffer--;
        
        //If the timer is still active when landing, jump again
        if (currentStatus == playerStatus.onGround && jumpBuffer > 0)
        {
            jump();
        }
        
        //Dampening force
        if (currentStatus == playerStatus.onGround && rb.velocity.x > 0.1)
        {
            rb.AddForce(dampeningConstant * new Vector2(rb.velocity.x, 0).normalized * -1);
        }
    }

    void jump()
    {
        animator.SetTrigger("jump");
        //rb.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
        rb.velocity = new Vector2(rb.velocity.x, jumpPower * 5);
    }
}
