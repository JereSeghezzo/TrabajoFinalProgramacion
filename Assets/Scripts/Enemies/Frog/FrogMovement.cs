using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool SafeJump;
    float jumpCD;
    [SerializeField] private float nextJump;
    [SerializeField] private float jumpForce;
    bool Flipped = true;

    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sprite = GetComponent<SpriteRenderer>();   
      animator = GetComponent<Animator>();
    }

    void Update()
    {
      if(IsGrounded == true && jumpCD < nextJump)
      {
        jumpCD += Time.deltaTime;  

        if(jumpCD >= nextJump)
        {
          if(SafeJump)
          {
           Jump();
          }else
          {
           Flip();
          }
        }  
      }

      if(IsGrounded)
      {
        animator.SetBool("Grounded", true);
        rb.velocity = new Vector2(0, rb.velocity.y);
      }else
      {
        animator.SetBool("Grounded", false);
      }
    }

    void Jump()
    {
     nextJump = Random.Range(2.5f,4.5f); 
     rb.AddForce(transform.right * -jumpForce * 100);
     rb.AddForce(transform.up * jumpForce * 140);
     jumpCD = 0f;
     SafeJump = false;
     IsGrounded = false;
     animator.SetBool("Grounded", false);
    }

    public void Flip()
    {
     Flipped = !Flipped;

     if(Flipped)
     {
     transform.rotation = Quaternion.Euler(0, 0, 0);
     }else 
     {
     transform.rotation = Quaternion.Euler(0, 180, 0);
     }
     jumpCD = 2.5f;
     //SafeJump = true;
    }
}
