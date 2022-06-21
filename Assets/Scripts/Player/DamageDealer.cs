using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

 public PlayerController player;

 [SerializeField] private float Impulse;
 void OnTriggerEnter2D(Collider2D col)
   {
     if (col.gameObject.CompareTag("frog"))
        {
         col.gameObject.GetComponent<FrogMovement>().TakeDamage(player.Damage);
         player.rb.AddForce(transform.up * Impulse * 100f);
        }
   }
}
