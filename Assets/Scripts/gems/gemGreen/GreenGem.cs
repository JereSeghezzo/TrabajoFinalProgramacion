using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGem : MonoBehaviour
{
 void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
         col.gameObject.GetComponent<PlayerController>().ColorToGreen();
          Destroy(gameObject);
        }
    }
}

