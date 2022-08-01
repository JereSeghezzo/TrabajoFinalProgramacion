using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStones : MonoBehaviour
{
    public GameObject Stone;
    public GameObject StoneBK;
    public GameObject StoneSpawner;
    float CD1;
    float CD;

    float CD1BK;
    float CDBK;

    public float MinDC;
    public float MaxCD;

    public float MinDCBK;
    public float MaxCDBK;

    void Update()
    {
      CD -= Time.deltaTime;
      if(CD <= 0f)  
      {
       DropStone();
      }

       CDBK -= Time.deltaTime;
      if(CDBK <= 0f)  
      {
       DropStoneBK();
      }
    }

  public void DropStone()
  {
   Instantiate(Stone, StoneSpawner.transform.position, transform.rotation);
   CD1 = Random.Range(MinDC,MaxCD);
   CD = CD1;
  }

  public void DropStoneBK()
  {
   Instantiate(StoneBK, StoneSpawner.transform.position, transform.rotation);
   CD1BK = Random.Range(MinDCBK,MaxCDBK);
   CDBK = CD1BK;
  }
}
