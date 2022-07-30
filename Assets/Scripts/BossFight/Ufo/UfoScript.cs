using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoScript : MonoBehaviour
{
 public GameObject player;
 public Sprite UfoEmpty;
 public GameObject FakeBoss;
public GameObject RealBoss;

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

 public void FakeBossEntrance()
 {
   FakeBoss.SetActive(true);  
 }

 public void RealBossEntrance()
 {
   RealBoss.SetActive(true);  
 }
}
