using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour,ITakeDamage
{
 [SerializeField] private int Health;

 void Update()
 {
   if(Health <= 0)
      {
        Destroy(gameObject);
      }
 }

  public void TakeDamage(int damage)
    {
      Health -= damage;
    }
}
