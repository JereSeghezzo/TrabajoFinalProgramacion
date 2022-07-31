using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

 void Update()
 {
if (Input.GetKey("j"))
        {
          Time.timeScale = 10f;  
        }

if (Input.GetKey("h"))
        {
          Time.timeScale = 1f;  
        }
 }
}
