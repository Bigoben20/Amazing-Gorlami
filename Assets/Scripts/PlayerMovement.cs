using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animation;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private int jumpCount = 0;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private enum MovementState
    {
        idle, running, jumping, falling, attack
    }

    [SerializeField] private AudioSource runSoundEffect;
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource fallSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        animation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpSoundEffect.Play();
        }

        // Movement Control and Animation     
        UpdateMovementState();
    }

    private void UpdateMovementState(){
        
        MovementState state;

        //Run Control
        if (Input.GetButtonDown("Fire1"))
        {
            state = MovementState.attack;
        }
        else if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        else if (dirX > 0f)
        {
            sprite.flipX = false;
            state = MovementState.running;

        }
        else if(dirX < 0f)
        {
            sprite.flipX = true;
            state = MovementState.running;
        }
        //Jumping Control and Animation
        else
        {
            state = MovementState.idle;
        }
        animation.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, .1f,jumpableGround); //ortali ayni boydan dondurulmeden bir tik altta
    }

}
