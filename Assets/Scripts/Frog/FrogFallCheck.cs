using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogFallCheck : MonoBehaviour
{
    public FrogMovement Frog;
    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor") == false)
        {
          Frog.SafeJump = false;  
        }

         if (col.gameObject.CompareTag("floor"))
        {
          Frog.SafeJump = true;  
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor") == false)
        {
          Frog.SafeJump = false;  
        }

         if (col.gameObject.CompareTag("floor"))
        {
          Frog.SafeJump = true;  
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
          Frog.SafeJump = false;  
        }
    }
}
