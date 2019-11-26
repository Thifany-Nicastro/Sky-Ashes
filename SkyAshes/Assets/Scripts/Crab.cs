using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght = 10f;
    [SerializeField] private float jumpHeight = 15f;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    private AudioSource explode;
    
    private bool facingLeft = true;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        explode = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        Move();
    }

    public void Move() 
    {
        if(facingLeft)
        {
            if(transform.position.x > leftCap)
            {
                if (transform.localScale.x != 1)
                {
                    transform.localScale = new Vector3(1, 1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-5, rb.velocity.y);
                    anim.SetBool("Walking", true);
                }
            }
            else
            {
                facingLeft = false;
            }
        }

        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x != -1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                if(coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(5, rb.velocity.y);
                    anim.SetBool("Walking", true);
                }
            }
            else
            {
                facingLeft = true;
            }
        }
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        explode.Play();
    }

}
