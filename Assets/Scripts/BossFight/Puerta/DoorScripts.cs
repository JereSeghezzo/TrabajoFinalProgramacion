using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScripts : MonoBehaviour
{
 public Animator FakeBoss;
 public GameObject UFO;
 public GameObject KeyAttacks;
 public GameObject SawPlataform;

 public GameObject[] LavaBlasts;

 public Animator Lava;

 public Animator DoorAnimator;
 public Animator VerticalPlataform;
 public GameObject HorizontalPlataform;
 public Animator Camera;
 public GameObject Star2;

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

    public void DeploySaw()
    {
      SawPlataform.SetActive(true);
    }

    public void DropStar2()
    {
      Star2.SetActive(true);
    }

    public void LavaBlast1()
    {
      LavaBlasts[0].SetActive(true); 
      print("1");
    }
     public void LavaBlast2()
    {
      LavaBlasts[1].SetActive(true); 
      print("2");
    }
     public void LavaBlast3()
    {
      LavaBlasts[2].SetActive(true); 
      print("3");
    }
     public void LavaBlast4()
    {
      LavaBlasts[3].SetActive(true); 
      print("4");
    }
     public void LavaBlast5()
    {
      LavaBlasts[4].SetActive(true); 
      print("5");
    }
     public void LavaBlast6()
    {
      LavaBlasts[5].SetActive(true); 
      print("6");
    }
     public void LavaBlast7()
    {
      LavaBlasts[6].SetActive(true); 
      print("7");
    }
     public void LavaBlast8()
    {
      LavaBlasts[7].SetActive(true); 
      print("8");
    }
     public void LavaBlast9()
    {
      LavaBlasts[8].SetActive(true); 
      print("9");
    }

     public void RiseLava()
    {
      Lava.SetBool("LavaActivate", true); 
    }

    public void SinkLava()
    {
      Lava.SetBool("LavaActivate", false); 
    }

    public void DeactivateKeyAttack()
    {
       KeyAttacks.SetActive(false);
    }

    public void TurningBig()
    {
      DoorAnimator.SetBool("TurnBig",true);
    }

    public void MoveVertialPlataformDown()
    {
      VerticalPlataform.SetBool("Active",true);
    }

    public void MoveVertialPlataformUp()
    {
      VerticalPlataform.SetBool("Active",false);
    }

    public void ActivateHorizontalPlataform()
    {
      HorizontalPlataform.SetActive(true);
    }

     public void DeactivateHorizontalPlataform()
    {
      HorizontalPlataform.SetActive(false);
    }

    public void ShakeCameraOn()
    {
      Camera.SetBool("Shake",true);
    }
     public void ShakeCameraOff()
    {
      Camera.SetBool("Shake",false);
    }

     public void CameraSmallShake()
    {
      Camera.SetTrigger("SmallShake");
    }
}
