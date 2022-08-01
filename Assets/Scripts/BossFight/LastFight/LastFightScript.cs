using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastFightScript : MonoBehaviour
{
    public GameObject[] LavaBlasts;
    int BlastNumber;
    int LastBlast;

    int BlastNumberP2;
    int LastBlastP2;

    int BlastNumberP3;
    int LastBlastP3;

    public float BlastCDP1;
    public float BlastCDP2;
    public float BlastCDP3;

    float CD;

    public bool Phase1;
    public bool Phase2;
    public bool Phase3;

    public float PhaseCounter;

    public float ActivePhase2;
    public float ActivePhase3;

    public Animator Plataform; // Active
    public Animator Lava; //LavaActivate

    public GameObject Star4_1;
    public GameObject Star4_2;
    public GameObject Star4_3;

    public float Star1Drop;
    public float Star2Drop;
    public float Star3Drop;


    void FixedUpdate()
    {
      CD -= Time.deltaTime;

      if(CD <= 0f && Phase1)
      {
        Phase1LavaBlasts();
      }   

      if(CD <= 0f && Phase2)
      {
        Phase2LavaBlasts();
      }   

      if(CD <= 0f && Phase3)
      {
        Phase3LavaBlasts();
      }   

      PhaseCounter += Time.deltaTime;

      if(PhaseCounter >= ActivePhase2 && PhaseCounter < ActivePhase3 && Phase2 == false)
      {
        Phase1 = false;
        Phase2 = true;
        Phase3 = false;
        StartCoroutine(LavaAndPlataformOn());
      }

      if(PhaseCounter >= ActivePhase3 && Phase3 == false)
      {
        Phase1 = false;
        Phase2 = false;
        Phase3 = true;
         StartCoroutine(LavaAndPlataformOff());
      }

      if(PhaseCounter >= Star1Drop && Star4_1.activeSelf == false)
      {
       Star4_1.SetActive(true); 
      }

      if(PhaseCounter >= Star2Drop && Star4_2.activeSelf == false)
      {
       Star4_2.SetActive(true); 
      }

      if(PhaseCounter >= Star3Drop && Star4_3.activeSelf == false)
      {
       Star4_3.SetActive(true); 
      }
    }


    public void Phase1LavaBlasts()
    {
     BlastNumber = Random.Range(0,9);

     if(BlastNumber == LastBlast)
     {
      Phase1LavaBlasts();
      //print(BlastNumber +" "+ LastBlast + "Repetido");
     } else 
     {
     LavaBlasts[BlastNumber].SetActive(true);  
     //print(BlastNumber +" "+ LastBlast + "Correcto");
     LastBlast = BlastNumber;
     CD = BlastCDP1;
     }
    }

     public void Phase2LavaBlasts()
    {
     BlastNumber = Random.Range(0,9);
     BlastNumberP2 = Random.Range(0,9);
     
     if(BlastNumber == LastBlast || BlastNumberP2 == LastBlastP2 || BlastNumber == BlastNumberP2 || BlastNumber == LastBlastP2 || BlastNumberP2 == LastBlast)
     {
      Phase2LavaBlasts();
     } else 
     {
     LavaBlasts[BlastNumber].SetActive(true);  
     LavaBlasts[BlastNumberP2].SetActive(true);  

     LastBlast = BlastNumber;
     LastBlastP2 = BlastNumberP2;

     CD = BlastCDP2;
     }
    }

     public void Phase3LavaBlasts()
    {
     BlastNumber = Random.Range(0,9);
     BlastNumberP2 = Random.Range(0,9);
     BlastNumberP3 = Random.Range(0,9);
     
     if(BlastNumber == LastBlast || BlastNumberP2 == LastBlastP2 || BlastNumberP3 == LastBlastP3 || BlastNumber == BlastNumberP2 || BlastNumberP2 == BlastNumberP3 || BlastNumber == BlastNumberP3 || BlastNumber == LastBlastP2 || BlastNumberP2 == LastBlast || BlastNumber == LastBlastP2 || BlastNumber == LastBlastP3 || BlastNumberP2 == LastBlast || BlastNumberP2 == LastBlastP3  || BlastNumberP3 == LastBlast || BlastNumberP3 == LastBlastP2)
     {
      Phase3LavaBlasts();
     } else 
     {
     LavaBlasts[BlastNumber].SetActive(true);  
     LavaBlasts[BlastNumberP2].SetActive(true);  
     LavaBlasts[BlastNumberP3].SetActive(true); 
    
     LastBlast = BlastNumber;
     LastBlastP2 = BlastNumberP2;
     LastBlastP3 = BlastNumberP3;
     
     CD = BlastCDP3;
     }
    }

     IEnumerator LavaAndPlataformOn()
     {
       Plataform.SetBool("Active", true);
       yield return new WaitForSeconds(6f); 
       Lava.SetBool("LavaActivate", true);
     }

     IEnumerator LavaAndPlataformOff()
     {
       Lava.SetBool("LavaActivate", false);
       yield return new WaitForSeconds(6f); 
       Plataform.SetBool("Active", false);
     }
}
