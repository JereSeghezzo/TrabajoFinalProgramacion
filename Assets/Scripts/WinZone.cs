using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D col) 
 {
    if (col.gameObject.CompareTag("Player"))
        {
         EventManager.PlayerWinEvent();
        }
 }
}
