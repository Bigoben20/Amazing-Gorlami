using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animation;
    private SpriteRenderer sprite;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;


    bool[] movement = {true, false, false}; // idle, run, jump



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    private void Update()
    {
        // Running Control and Animation           
        UpdateRunning(Input.GetAxisRaw("Horizontal"));    

        UpdateJumping(Input.GetButtonDown("Jump"));
    }

    private void MovementControl(){
        if (Input.GetButtonDown("Jump") == true)
        {
            movement[0]=false;
            movement[1]=false;
            movement[2]=true;

        }else if(Input.GetAxisRaw("Horizontal") != 0f && Input.GetButtonDown("Jump") == false){
            movement[0]=false;
            movement[1]=true;
            movement[2]=false;
        }else{
            movement[0]=true;
            movement[1]=false;
            movement[2]=false;
        }
    }

    private void UpdateJumping(bool input){

        //Jumping Control and Animation
        if (input)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animation.SetBool("jumping", true);
        }else{
            animation.SetBool("jumping", false);
        }
    }

    private void UpdateRunning(float input){

        dirX = input;
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (dirX > 0f)
        {
            animation.SetBool("running", true);
            sprite.flipX = false;

        }else if(dirX < 0f){
            animation.SetBool("running", true);
            sprite.flipX = true;
        }else
        {
            animation.SetBool("running", false);
        }
    }
}
