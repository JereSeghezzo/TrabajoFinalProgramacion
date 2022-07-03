using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedFlash : MonoBehaviour
{
    SpriteRenderer sprite;
    PlayerController player;

 void Start()
 {
   player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();  
   sprite = GetComponent<SpriteRenderer>();
 }
 
public IEnumerator FlashRed()
 {
    if(player.SizeState == PlayerController.AlienSizeState.Big)
    {
    sprite.color = Color.red;
    yield return new WaitForSeconds(0.1f);
    sprite.color = Color.white;
    }
 }
}
