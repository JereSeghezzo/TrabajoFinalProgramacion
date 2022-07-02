using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour,ITakeDamage
{
 public Enemies enemy;

 [SerializeField] private int _health;
 [SerializeField] private int _damage;
 public GameObject particles;

 void Start()
 {
  _health = enemy.Health;
  _damage = enemy.Damage;
 }

  public void TakeDamage(int damage)
    {
      _health -= damage;

      if(_health <= 0)
      {
        Destroy(gameObject);
        Instantiate(particles, transform.position, transform.rotation);
      }
    }
}
