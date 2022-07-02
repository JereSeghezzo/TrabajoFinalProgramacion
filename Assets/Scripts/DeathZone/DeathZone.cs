using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D col) 
 {
    if (col.gameObject.CompareTag("Player"))
        {
         EventManager.PlayerDeathEvent();
        }
 }
}
