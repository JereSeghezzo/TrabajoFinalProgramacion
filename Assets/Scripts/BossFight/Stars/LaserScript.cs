using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
 public GameObject Explotion;
 public GameObject laser;

 void OnTriggerEnter2D(Collider2D col) 
 {
   if (col.gameObject.CompareTag("Puerta"))
        {
         Instantiate(Explotion, transform.position, transform.rotation);
         Destroy(laser.gameObject);
        } 
 }
}
