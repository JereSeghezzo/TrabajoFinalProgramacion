using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallZone : MonoBehaviour
{
 void OnTriggerStay2D(Collider2D col) 
 {
    if (col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerController>().SizeState == PlayerController.AlienSizeState.Big)
        {
         EventManager.PlayerDeathEvent();
        }
 }
}
