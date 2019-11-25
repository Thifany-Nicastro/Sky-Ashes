using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] private float rightCap;

    [SerializeField] private float jumpLenght;
    [SerializeField] private float jumpHeight;
    [SerializeField] private LayerMask ground;
    private Collider2D coll;
    private Rigidbody2D rb;
    private Animator anim;
    
    private bool facingLeft = true;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void JumpedOn()
    {
        anim.SetTrigger("Death");
    }

    private void Death()
    {
        Destroy(this.gameObject);
    }

}
