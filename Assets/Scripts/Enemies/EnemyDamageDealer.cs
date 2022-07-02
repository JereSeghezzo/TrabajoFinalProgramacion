using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
public EnemyStats Enemy;
[SerializeField] float HitCD;
float CD;

void FixedUpdate()
{
  if(CD <= HitCD)
  CD += Time.deltaTime;
}

 void OnCollisionStay2D(Collision2D col)
   {
     if (col.gameObject.CompareTag("Player") && CD >= HitCD)
        {
         col.gameObject.GetComponent<PlayerController>().TakeDamage(Enemy.enemy.Damage);
         CD = 0f;
        }
   }
}
