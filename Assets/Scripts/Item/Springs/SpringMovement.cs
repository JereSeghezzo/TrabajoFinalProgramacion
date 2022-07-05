using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringMovement : MonoBehaviour
{
    public SpringManager _Script;
    GameObject player;
    [SerializeField] private float SpringForce;

 void OnCollisionEnter2D(Collision2D  col)
 {
   if(col.gameObject.CompareTag("Player") ) 
   {

    player = col.gameObject;

     if(_Script.Spring.activeSelf && player.transform.position.y > (transform.position.y + 0.2f) && player.GetComponent<PlayerController>().SizeState == PlayerController.AlienSizeState.Small)
     {
       _Script.SpringUp(); 
        player.GetComponent<Rigidbody2D>().AddForce(transform.up * SpringForce * 100);
     }
   }
 }
}
