using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour
{
 public GameObject player;
 public Sprite UfoEmpty;

 [HideInInspector] public SpriteRenderer sprite;

 void Start()
 {
   sprite = GetComponent<SpriteRenderer>();
 }


 public void UfoArrived()
 {
  player.SetActive(true);
  sprite.sprite = UfoEmpty;
 }
}
