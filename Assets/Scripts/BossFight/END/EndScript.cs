using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndScript : MonoBehaviour
{
    public GameObject BlackScreen;


 public void BlackScreen_()
 {
   BlackScreen.SetActive(true); 
 }

 public void end()
 {
   SceneManager.LoadScene("MainMenu");
 }
}
