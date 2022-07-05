using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

 void Start()
 {
  EventManager.GameOverEvent += LevelReset;
  EventManager.WinEvent += LevelComplete;
 }

 void LevelReset()
 {
  print("You died");
 }

 void LevelComplete()
 {
  print("You Won");
 }
}
