using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogGroundCheck : MonoBehaviour
{
    public FrogMovement Frog;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Untagged"))
        {
            Frog.IsGrounded = true;
        }

        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("EnemyDamageDealer"))
        {
            Frog.Flip();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            Frog.IsGrounded = false;  
        }
    }
}