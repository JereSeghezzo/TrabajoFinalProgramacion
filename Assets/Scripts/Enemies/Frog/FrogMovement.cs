using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    [HideInInspector]public bool IsGrounded;
    [HideInInspector]public bool SafeJump;
    float jumpCD;
    [SerializeField] private float nextJump;
    [SerializeField] private float jumpForce;
    public int Damage;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    public GameObject FallCheckL;
    public GameObject FallCheckR;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      sprite = GetComponent<SpriteRenderer>();   
    }

    void Update()
    {
      if(IsGrounded == true)
      {
        if(jumpCD < nextJump)
        {
          jumpCD += Time.deltaTime;  
          if(jumpCD >= nextJump)
          {
              if(SafeJump == true)
              {
              Jump();
              } else if(SafeJump == false)
              {
                Flip();  
              }
          } 
        }
      }  

      if(sprite.flipX)
      {
       FallCheckR.SetActive(true);
       FallCheckL.SetActive(false);
      } else if(!sprite.flipX)
      {
       FallCheckR.SetActive(false);
       FallCheckL.SetActive(true);
      }
    }

    void Jump()
    {
     if(!sprite.flipX)
     {
     rb.AddForce(transform.right * -jumpForce * 100);
     }
     if(sprite.flipX)
     {
     rb.AddForce(transform.right * jumpForce * 100);
     }
     rb.AddForce(transform.up * jumpForce * 140);
     jumpCD = 0f;
     SafeJump = false;
     IsGrounded = false;
    }

    void Flip()
    {
      sprite.flipX = !sprite.flipX;
      jumpCD = 2.5f;
      SafeJump = true;
    }
}
