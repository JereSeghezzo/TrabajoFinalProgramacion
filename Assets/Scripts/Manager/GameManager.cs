using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

 void Start()
 {
  EventManager.GameOverEvent += LevelReset;
  EventManager.WinEvent += LevelComplete;
 }

 void OnDisable()
    {
      EventManager.GameOverEvent -= LevelReset;
      EventManager.WinEvent -= LevelComplete;
    }

 void LevelReset()
 {
  StartCoroutine(Restart());
 }

 void LevelComplete()
 {
  SceneManager.LoadScene("BossFight");
 }

 IEnumerator Restart()
 {
  yield return new WaitForSeconds(2f);
  SceneManager.LoadScene("FinalProg");  
 }
}
