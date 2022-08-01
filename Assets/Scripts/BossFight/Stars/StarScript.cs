using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
  public GameObject Laser;
  public GameObject GreenGem;

  public bool Star1;

  void OnTriggerEnter2D(Collider2D col) 
 {
   if (col.gameObject.CompareTag("Player"))
        {  
         //laser.LaserAttack1();
         Instantiate(Laser, transform.position, transform.rotation); 
         if(Star1)
         {
         GreenGem.SetActive(true);
         }
         Destroy(gameObject);
        } 
 }

}
