using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController player;
    public Animator animator;


    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            player.IsGrounded = true;
            player.change = true;
            animator.SetBool("Jumping", false); 
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            player.stunned = false;
            animator.SetBool("Hit", false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            player.IsGrounded = false;
        }
    }
}
