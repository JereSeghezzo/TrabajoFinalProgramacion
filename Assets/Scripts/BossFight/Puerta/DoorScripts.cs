using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{
 public Animator FakeBoss;
 public GameObject UFO;
 public GameObject KeyAttacks;

    public void FakeBossDeath()
    {
      FakeBoss.SetBool("Death", true);
    }

     public void UfoDestroy()
    {
      UFO.SetActive(false);
    }

     public void UseKeyAttackLeft()
    {
      KeyAttacks.SetActive(true);
    }

}
