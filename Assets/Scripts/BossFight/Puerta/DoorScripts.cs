using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{
 public Animator FakeBoss;

    public void FakeBossDeath()
    {
      FakeBoss.SetBool("Death", true);
    }

}
