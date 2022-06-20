using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Alien State")]
    public string State;

    private float runSpeed;
    private float jumpForce;

    [Header("Gravity Force")]
    [SerializeField] private float Gforce;

    [Header("Stats When Normal Size")]
    [SerializeField] private float runSpeedBig;
    [SerializeField] private float jumpForceBig;

    [Header("Stats When Small Size")]
    [SerializeField] private float runSpeedSmall;
    [SerializeField] private float jumpForceSmall;

    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool change;

    [Header("Ability Cool Down")]
    [SerializeField] private float AbilityCD;
    private float _abilityCD;

    private float camsize = 9;

    bool grow;
    bool gravity;

    [Header("GroundChecks")]
    public GameObject groundCheck1;
    public GameObject groundCheck2;

    Rigidbody2D rb;
    SpriteRenderer sprite;

    [Header("Camera")]
    public Camera cam;

    [Header("Alien Sprites")]
    public Sprite GreenAlien;
    public Sprite YellowAlien;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        Gforce = 16;
        camsize = 9;
        runSpeed = runSpeedBig;
        jumpForce = jumpForceBig;
        gravity = true;
        _abilityCD = AbilityCD;
    }

    void Update()
    {
     if(_abilityCD < AbilityCD)
     {
      _abilityCD += Time.deltaTime;
     }    
    
     Movement();

     CameraSizeAdjust();

     if (Input.GetKeyDown("w") && IsGrounded == true)
        {
          CharacterChange();
        }

     if (Input.GetKeyDown("f") && _abilityCD >= AbilityCD)
        {
          if(State == "Green")
          {
            GravityChange();
          }else if(State == "Yellow")
          {
            SizeChange();
          }

          _abilityCD = 0f;
        } 
    }

    public void Movement()
    {
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
        if (Input.GetKeyDown("space") && gravity == true && IsGrounded == true)
        {
            rb.AddForce(transform.up * jumpForce * 100);
        
        }

        if (Input.GetKeyDown("space") && gravity == false && IsGrounded == true)
        {
            rb.AddForce(transform.up * -jumpForce * 100);

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
    }

   void GravityChange()
   {
     if (change)
        {
        gravity = !gravity;
        change = false;
        }
   }

   void SizeChange()
   {
    if (!grow)
        {
        transform.localScale -= new Vector3(0.8f, 0.8f, 0.8f);
        grow = !grow;
        runSpeed = runSpeedSmall;
        jumpForce = jumpForceSmall;
        } else  if (grow)
        {
        transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
        grow = !grow;
        runSpeed = runSpeedBig;
        jumpForce = jumpForceBig;
        }
   }

   void CameraSizeAdjust()
   {
    cam.orthographicSize = camsize;
    if(!grow && camsize < 9f)
        {
            camsize += Time.deltaTime * 20f;
        }

        if (grow && camsize > 2.5f)
        {
            camsize -= Time.deltaTime * 20f;
        }
   }

   void CharacterChange()
   {
    if(State == "Green")
        {
            State = "Yellow";
            sprite.sprite = YellowAlien;
        } else if(State == "Yellow")
        {
            State = "Green";
            sprite.sprite = GreenAlien;
        }

     gravity = true;

     if (grow)
        {
        transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
        grow = !grow;
        }

     runSpeed = runSpeedBig;
     jumpForce = jumpForceBig;
   }
}
