using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PlayerController player;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.CompareTag("Untagged"))
        {
            player.IsGrounded = true;
            player.change = true;
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
