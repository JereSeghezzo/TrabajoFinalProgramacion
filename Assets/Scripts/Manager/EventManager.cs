using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
 public static event Action GameOverEvent;
 public static event Action WinEvent;

 public static void PlayerDeathEvent()
 {
    GameOverEvent?.Invoke();
 }

 public static void PlayerWinEvent()
 {
    WinEvent?.Invoke();
 }
}
