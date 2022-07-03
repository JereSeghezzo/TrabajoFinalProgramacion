using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController player;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
            player.IsGrounded = true;
            player.change = true;
            player.stunned = false;
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
