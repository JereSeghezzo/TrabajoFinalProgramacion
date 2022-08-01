using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser3Script : MonoBehaviour
{
 public GameObject Explotion;
 public GameObject laser;
 public DoorSpriteChange door;
 public bool Pum;

 public GameObject ExplotionEnd;


 public void Collide()
 {
   Instantiate(Explotion, laser.transform.position, laser.transform.rotation);
   if(Pum)
   {
    door = GameObject.FindGameObjectWithTag("Puerta").GetComponent<DoorSpriteChange>(); 
    door.DoorBroken2 = false;
    door.DoorBroken3 = true;
   }
   Destroy(gameObject); 
 }

 public void CollideEND()
 {
   Instantiate(ExplotionEnd, laser.transform.position, laser.transform.rotation);
   Destroy(gameObject); 
 }
}
