using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

 public PlayerController player;

 [SerializeField] private float ImpulseBig;
 [SerializeField] private float ImpulseSmall;

 void OnTriggerEnter2D(Collider2D col)
   {
     if (col.gameObject.CompareTag("Enemy"))
        {
         col.gameObject.GetComponent<EnemyStats>().TakeDamage(player.Damage);
         if(player.SizeState == PlayerController.AlienSizeState.Big)
         {
         player.rb.AddForce(transform.up * ImpulseBig * 100f);
         } else if(player.SizeState == PlayerController.AlienSizeState.Small)
         {
         player.rb.AddForce(transform.up * ImpulseSmall * 100f);
         }
         player.IsGrounded = false;
        }
   }
}
