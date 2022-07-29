using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{

    PlayerController player;
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();  
    }

    void Update()
    {
      if(gameObject.transform.position.x <= -32.2f)
      {
        player.LeftBorder = true;
      }  else player.LeftBorder = false;

      if(gameObject.transform.position.x >= 30.92)
      {
        player.RightBorder = true;
      }  else player.RightBorder = false;
    }
}
