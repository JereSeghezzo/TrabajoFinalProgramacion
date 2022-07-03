using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
public EnemyStats Enemy;
[SerializeField] float HorizontalKb;
[SerializeField] float VerticalKb;

Rigidbody2D rb;
PlayerController player;

 void OnCollisionStay2D(Collision2D col)
   {
     if (col.gameObject.CompareTag("Player") )
        {
         rb = col.gameObject.GetComponent<Rigidbody2D>();
         player = col.gameObject.GetComponent<PlayerController>();
         player.TakeDamage(Enemy.enemy.Damage);
         
         rb.velocity = new Vector2(0, 0);

         if(transform.position.x < col.gameObject.transform.position.x && transform.rotation == Quaternion.Euler(0, 0, 0)) //left
        {
          rb.AddForce(transform.right * HorizontalKb * 100);
        }else if(transform.position.x >= col.gameObject.transform.position.x && transform.rotation == Quaternion.Euler(0, 0, 0)) //right
        {
          rb.AddForce(transform.right * -HorizontalKb * 100);
        }

        if(transform.position.x < col.gameObject.transform.position.x && transform.rotation == Quaternion.Euler(0, -180, 0)) //right
        {
          rb.AddForce(transform.right * -HorizontalKb * 100);
        }else if(transform.position.x >= col.gameObject.transform.position.x && transform.rotation == Quaternion.Euler(0, -180, 0)) //left
        {
          rb.AddForce(transform.right * HorizontalKb * 100);
        }

         if(player.gravity)
        {
         rb.AddForce(transform.up * VerticalKb * 100);
        }else
        {
         rb.AddForce(transform.up * -VerticalKb * 100);
        }
         
         player.stunned = true;
        }
   }
}
