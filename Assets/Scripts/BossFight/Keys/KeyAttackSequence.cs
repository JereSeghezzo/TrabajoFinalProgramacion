using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAttackSequence : MonoBehaviour
{
 public GameObject[] Attacks;

 public Animator Plataform;
 
 public Animator DoorAnimator;

 public void Attack2()
 {
   Attacks[1].SetActive(true);
 }

  public void Attack3()
 {
   Attacks[2].SetActive(true);
 }

  public void Attack4()
 {
   Attacks[3].SetActive(true);
 }

  public void Attack5()
 {
   Attacks[4].SetActive(true);
 }

  public void Attack6()
 {
   Attacks[5].SetActive(true);
 }

  public void Attack7()
 {
   Attacks[6].SetActive(true);
 }

  public void Attack8()
 {
   Attacks[7].SetActive(true);
 }

  public void Attack9()
 {
   Attacks[8].SetActive(true);
 }

 public void PullDownPlataform()
 {
  Plataform.SetBool("Active", true);
 }

 public void EndKeyAttack()
    {
      DoorAnimator.SetBool("LavaAttackUp", true);
    }
 
}
