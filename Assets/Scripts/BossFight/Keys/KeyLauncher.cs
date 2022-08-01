using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLauncher : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();   
      Destroy(gameObject, 6f);
    }
    void Update()
    {
      rb.velocity = new Vector2(-Speed, rb.velocity.y);  
    }
}
