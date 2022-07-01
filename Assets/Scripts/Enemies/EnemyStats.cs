using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour,ITakeDamage
{
 public Enemies enemy;

 [SerializeField] private int _health;
 [SerializeField] private int _damage;

 void Start()
 {
  _health = enemy.Health;
  _damage = enemy.Damage;

 }

 void Update()
 {
   if(_health <= 0)
      {
        Destroy(gameObject);
      }
 }

  public void TakeDamage(int damage)
    {
      _health -= damage;
      Debug.Log(_health);
    }
}
