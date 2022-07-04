using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringManager : MonoBehaviour
{
 public GameObject Spring;
 public GameObject Sprung;
 Animator animator;

 void Start()
 {
   animator = GetComponent<Animator>();
   Spring.SetActive(false);
   Sprung.SetActive(true); 
 }

  void OnTriggerStay2D(Collider2D col)
 {
  if (Input.GetKey("e") && col.gameObject.CompareTag("Player") && col.gameObject.GetComponent<PlayerController>().SizeState == PlayerController.AlienSizeState.Big)
  {
   Spring.SetActive(true);
   Sprung.SetActive(false);
   animator.ResetTrigger("ToLeft");
   animator.SetTrigger("ToRight");
  }
 }

  public void SpringUp()
  {
   Spring.SetActive(false);
   Sprung.SetActive(true);
   animator.ResetTrigger("ToRight");
   animator.SetTrigger("ToLeft");
   
  }
}
