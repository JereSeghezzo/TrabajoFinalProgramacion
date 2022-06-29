using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{
 public PlayerController player;
 void OnCollisionEnter2D(Collision2D col) 
 {
    if(col.gameObject.CompareTag("Player"));
    {
      player = col.gameObject.GetComponent<PlayerController>();
      if(player.SizeState == PlayerController.AlienSizeState.Big)
      {
       Destroy(gameObject);
      }
    }
 }
}
