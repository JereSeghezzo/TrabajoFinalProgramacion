using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpriteChange : MonoBehaviour
{
    public Sprite Door2;
    public Sprite Door3;

    SpriteRenderer sprite;

    public bool DoorBroken2;
    public bool DoorBroken3;

    void Start()
    {
     sprite = GetComponent<SpriteRenderer>();

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
    }
}
