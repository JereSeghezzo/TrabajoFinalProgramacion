using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour,ITakeDamage
{
 public Enemies enemy;

 [SerializeField] private int _health;
 [SerializeField] private int _damage;
 public GameObject particles;
 EnemyRedFlash Flash;
 bool _flash;

 void Start()
 {
  Flash = GetComponent<EnemyRedFlash>();
  _health = enemy.Health;
  _damage = enemy.Damage;

  if(Flash == null) 
  {
   _flash = false;
  }else
  {
   _flash = true;
  }
 }

  public void TakeDamage(int damage)
    {
      _health -= damage;
      
      if(_flash)
      {
      StartCoroutine(Flash.FlashRed());
      }
      
      if(_health <= 0)
      {
        Destroy(gameObject);
        Instantiate(particles, transform.position, transform.rotation);
      }
    }
}
