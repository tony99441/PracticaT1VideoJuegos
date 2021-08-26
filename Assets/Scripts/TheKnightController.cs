using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheKnightController : MonoBehaviour
{
    public float velocityX;
    public float velocityCaminarX;
    public float Salto;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator; 
    
    //Const
    private const int Idle = 0; 
    private const int Walk = 1; 
    private const int Run = 2; 
    private const int Attack = 3;
    private const int Jump = 4; 
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y); 
        cambiarAnimacion(Idle);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocityCaminarX, rb.velocity.y);
            sr.flipX = true; 
            cambiarAnimacion(Walk);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityCaminarX, rb.velocity.y);
            sr.flipX = false; 
            cambiarAnimacion(Walk);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(-velocityX, rb.velocity.y);
            sr.flipX = true; 
            cambiarAnimacion(Run);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false; 
            cambiarAnimacion(Run);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            cambiarAnimacion(Attack);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(Vector2.up*Salto, ForceMode2D.Impulse);
            cambiarAnimacion(Jump);
        }



    }

    private void cambiarAnimacion(int animation)
    {
        animator.SetInteger("Estado", animation);
    }

}
