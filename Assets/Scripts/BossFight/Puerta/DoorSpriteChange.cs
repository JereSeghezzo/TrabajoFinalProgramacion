using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpriteChange : MonoBehaviour
{
    public Sprite Door2;
    public Sprite Door3;
    public Sprite Door4;

    SpriteRenderer sprite;

    public bool DoorBroken2;
    public bool DoorBroken3;
    public bool DoorBroken4;

    public int DoorHealth;

    public Animator Animator;

    void Start()
    {
     sprite = GetComponent<SpriteRenderer>();
     DoorHealth = 3;

    }

    void LateUpdate()
    {
        if(DoorBroken2)
        {
      sprite.sprite = Door2;
        }

        if(DoorBroken3)
        {
      sprite.sprite = Door3;
        }

        if(DoorBroken4)
        {
      sprite.sprite = Door4;
        }
    }

  public void LastFightHit()
  {
    DoorHealth -= 1;

    if(DoorHealth == 0)
    {
      DoorBroken2 = false;
      DoorBroken3 = false;
      DoorBroken4 = true;
      Animator.SetTrigger("Death");
    }
  }  
}
