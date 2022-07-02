using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormMovement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float Speed;
    bool flipped = true;

    void Start()
    {
     rb = GetComponent<Rigidbody2D>();  
    }

    void FixedUpdate()
    {
     Move();
    }

 public void Flip()
 {
    flipped = !flipped;
    if(flipped)
    {
     transform.rotation = Quaternion.Euler(0, 0, 0);
    }else 
    {
     transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    
 }

 void Move()
 {
    if(flipped)
    {
    rb.velocity = new Vector2(-Speed, rb.velocity.y);
    }
    if(!flipped)
    {
    rb.velocity = new Vector2(Speed, rb.velocity.y);
    }
 }
}
