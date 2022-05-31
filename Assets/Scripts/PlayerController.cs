using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private float Gforce;

    bool gravity;

    public bool IsGrounded;
    public bool change;

    private float camsize = 9;

    bool grow;

    public GameObject groundCheck1;
    public GameObject groundCheck2;


    Rigidbody2D rb;
    SpriteRenderer sprite;
    public Camera cam;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        Gforce = 16;
        camsize = 9;
        runSpeed = 10f;
        jumpForce = 5f;
        gravity = true;

    }
    void Update()
    {
        if(!grow && camsize < 9f)
        {
            camsize += Time.deltaTime * 20f;
        }

        if (grow && camsize > 2.5f)
        {
            camsize -= Time.deltaTime * 20f;
        }

       
    

        cam.orthographicSize = camsize;

        if (Input.GetKeyDown("w") && change)
        {
            gravity = !gravity;
            change = false;
        }

        if (Input.GetKeyDown("f") && !grow)
        {
           transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
            grow = !grow;
        }

        if (Input.GetKeyDown("g") && grow)
        {
            transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
            grow = !grow;
        }
        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
        }

        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if(gravity)
        {
            rb.AddForce(transform.up * -Gforce);
            sprite.flipY = false;

            groundCheck1.SetActive(true);
            groundCheck2.SetActive(false);
        }

        if (!gravity)
        {
           rb.AddForce(transform.up * Gforce);
            sprite.flipY = true;

            groundCheck1.SetActive(false);
            groundCheck2.SetActive(true);
        }

        if (Input.GetKeyDown("space") && gravity == true && IsGrounded == true)
        {
            rb.AddForce(transform.up * jumpForce * 100);
        
        }

        if (Input.GetKeyDown("space") && gravity == false && IsGrounded == true)
        {
            rb.AddForce(transform.up * -jumpForce * 100);

        }
    }

 
}
