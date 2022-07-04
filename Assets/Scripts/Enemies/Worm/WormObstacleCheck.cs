using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormObstacleCheck : MonoBehaviour
{
    public WormMovement worm;

     void OnTriggerEnter2D(Collider2D col)
    {
         if(!col.gameObject.CompareTag("Player") && !col.gameObject.CompareTag("Untagged")) 
        {
          worm.Flip();  
        }
    }

}
