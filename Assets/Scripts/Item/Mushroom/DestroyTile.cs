using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTile : MonoBehaviour
{
 void OnCollisionEnter2D(Collision2D col) 
 {
    if(col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerController>().StateSize == "Big")
    {
      Destroy(gameObject);
    }
 }
}
