using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLancherScript : MonoBehaviour
{ 
    public float KeyLaunchCD;
    float CD;

    public GameObject[] Keys;

    GameObject Key;

    void Update()
    {
      CD -= Time.deltaTime;  

      if(CD <= 0)
      {
       Launch();
       CD = KeyLaunchCD;
      }
    }

      public void Launch()
      {
       Key = Keys[Random.Range(0,4)];
       Instantiate(Key, transform.position, transform.rotation); 
      }
}
