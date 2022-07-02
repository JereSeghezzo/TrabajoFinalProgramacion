using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour
{
    [SerializeField] private float FollowSpeed;
    [SerializeField] private float ReturnSpeed;
    [SerializeField] private float ChaseDist;
    bool chasing;
    public bool chase;
    public Transform startingPoint;
    private GameObject player;
    float dist;
   
    void Start()
    {
     player = GameObject.FindGameObjectWithTag("Player"); 
    }

    void Update()
    {
      if(player == null)
       return;

      if(dist <= ChaseDist && player.GetComponent<PlayerController>().SizeState == PlayerController.AlienSizeState.Big && chase == true)
      {
        Chase();
      } else if(chasing == true && player.GetComponent<PlayerController>().SizeState == PlayerController.AlienSizeState.Small && chase == true)
      {
        Chase();
      }else 
      {
       ReturnStartPoint();
      }

      Flip();
      Distance();
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, FollowSpeed * Time.deltaTime);
        chasing = true;
    }

    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
         transform.rotation = Quaternion.Euler(0, 0, 0);
        else
         transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.transform.position, ReturnSpeed * Time.deltaTime);
        chasing = false;
    }

    void Distance()
    {
      dist = Vector3.Distance(player.GetComponent<Transform>().position, transform.position);
    }
}
