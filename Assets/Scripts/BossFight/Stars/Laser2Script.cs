using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser2Script : MonoBehaviour
{
 public GameObject Explotion;
 public GameObject laser;

 void OnTriggerEnter2D(Collider2D col) 
 {
   if (col.gameObject.CompareTag("Puerta"))
        {
         Instantiate(Explotion, transform.position, transform.rotation);
         col.GetComponent<DoorSpriteChange>().DoorBroken2 = true;
         Destroy(laser.gameObject);
        } 
 }
}
