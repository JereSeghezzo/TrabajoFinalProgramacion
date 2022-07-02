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

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sprite = GetComponent<SpriteRenderer>();   
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
    }

    void Jump()
    {
     rb.AddForce(transform.right * -jumpForce * 100);
     rb.AddForce(transform.up * jumpForce * 140);
     jumpCD = 0f;
     SafeJump = false;
     IsGrounded = false;
    }

    void Flip()
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
     SafeJump = true;
    }
}
