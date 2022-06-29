using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gems : MonoBehaviour
{
  public PlayerController player;

  public abstract void Action();

  void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
         player = col.gameObject.GetComponent<PlayerController>();
         
         Action();
        }
    }
  
}
