using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionScript : MonoBehaviour
{
 
 DoorSpriteChange door;
 
 private void Start() 
 {
  door = GameObject.FindGameObjectWithTag("Puerta").GetComponent<DoorSpriteChange>();
 }
 
 public void Finish()
 {
   Destroy(gameObject);
 }

 public void DoorHit()
 {
  door.LastFightHit();
 }
}
