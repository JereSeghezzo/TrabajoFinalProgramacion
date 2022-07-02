using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFallCheck : MonoBehaviour
{
 public WormMovement worm;

     void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("floor"))
        {
          worm.Flip();
        }
    }
}
