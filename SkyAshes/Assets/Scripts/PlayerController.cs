using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private enum State {idle, running, jumping, falling, hurt}
    private State state = State.idle;
    
    //Inspector
    [SerializeField] private LayerMask ground;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float hurtForce = 7f;
    [SerializeField] private int health = 3;
    [SerializeField] private Text healthAmount;
    [SerializeField] private AudioSource hurt;
    [SerializeField] private AudioSource footstep;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        healthAmount.text = health.ToString();
    }

    private void Update()
    {
        if(state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if(state == State.falling)
            {
                enemy.JumpedOn();
                Jump();
            }
            else
            {
                hurt.Play();
                state = State.hurt;
                HandleHealth();
                if(other.gameObject.transform.position.x > transform.position.x)
                {
                    //Enemy right
                    rb.velocity = new Vector2(-hurtForce, hurtForce);
                }
                else
                {
                    //Enemy left
                    rb.velocity = new Vector2(hurtForce, hurtForce);
                }
            }
        }
        if(other.gameObject.tag == "Water")
        {
            Restart();
        }
    }

    private void HandleHealth()
    {
        health -= 1;
        healthAmount.text = health.ToString();
        if(health <= 0)
        {
            Restart();
        }
    }

    private void Movement()
    {
        float hDirection = Input.GetAxisRaw("Horizontal");

        //left
        if(hDirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        //right
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else 
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        //jumping
        if (Input.GetButtonDown("Jump") && coll.IsTouchingLayers(ground))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void AnimationState()
    {
        if(state == State.jumping)
        {
            if(rb.velocity.y < .1f)
            {
                state = State.falling;
            }
        }
        else if(state == State.falling)
        {
            if(coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < .1f)
            {
                state = State.idle;
            }
        }
        else if(Mathf.Abs(rb.velocity.x) > 2f)
        {
            //Moving
            state = State.running;
        }
        else
        {
            state = State.idle;
        }
    }

    private void Footstep()
    {
        footstep.Play();
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
