using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogDamageDealer : MonoBehaviour
{
public FrogMovement frog;

 void OnCollisionEnter2D(Collision2D col)
   {
     if (col.gameObject.CompareTag("Player"))
        {
         col.gameObject.GetComponent<PlayerController>().TakeDamage(frog.Damage);
        }
   }
}
