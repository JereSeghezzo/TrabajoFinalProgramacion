using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,ITakeDamage
{
    public enum AlienColorState{Green, Blue};
    public enum AlienSizeState{Small, Big};

    public AlienColorState ColorState;
    public AlienSizeState SizeState;

    [HideInInspector] public float runSpeed;
    [HideInInspector] public float jumpForce;

    [Header("Health")]
    [SerializeField] private int Health;

    [HideInInspector]public int Damage;

    private float Gforce;

    [Header("Stats When Normal Size")]
    [SerializeField] private float runSpeedBig;
    [SerializeField] private float jumpForceBig;
    [SerializeField] private float GforceBig;
    [SerializeField] private int DamageBig;
    

    [Header("Stats When Small Size")]
    [SerializeField] private float runSpeedSmall;
    [SerializeField] private float jumpForceSmall;
    [SerializeField] private float GforceSmall;
    [SerializeField] private int DamageSmall;
    

    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool change;

    [Header("Ability Cool Down")]
    [SerializeField] private float AbilityCD;
    private float _abilityCD;

    private float camsize = 9;

    bool grow;
    bool gravity;

    [Header("GroundChecks")]
    public GameObject groundCheck;

    [HideInInspector] public Rigidbody2D rb;
    SpriteRenderer sprite;

    [Header("Camera")]
    public Camera cam;

    [Header("Alien Sprites")]
    public Sprite GreenAlien;
    public Sprite BlueAlien;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        EventManager.GameOverEvent += Death;

        Gforce = 16;
        camsize = 9;
        runSpeed = runSpeedBig;
        jumpForce = jumpForceBig;
        gravity = true;
        _abilityCD = AbilityCD;

        ColorState = AlienColorState.Blue;
        SizeState = AlienSizeState.Big;
    }

    void Update()
    {
     if(_abilityCD < AbilityCD)
     {
      _abilityCD += Time.deltaTime;
     }    
    
     Movement();

     CameraSizeAdjust();

     if (Input.GetKeyDown("f") && _abilityCD >= AbilityCD)
        {
          if(ColorState == AlienColorState.Green)
          {
            GravityChange();
          }else if(ColorState == AlienColorState.Blue)
          {
            SizeChange();
          }

          _abilityCD = 0f;
        } 
    }

    public void Movement()
    {
      rb.AddForce(transform.up * -Gforce);

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
        if (Input.GetKeyDown("space") && IsGrounded == true)
        {
            rb.AddForce(transform.up * jumpForce * 100);
            IsGrounded = false;
        }
    }

   void GravityChange()
   {
     if (change)
      {
        gravity = !gravity;
        change = false;

        if(gravity)
        {
          transform.rotation = Quaternion.Euler(0, 0, 0);
        }else if(!gravity)
        {
          transform.rotation = Quaternion.Euler(180, 0, 0);
        }
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
        Gforce = GforceSmall;
        SizeState = AlienSizeState.Small;
        Damage = DamageSmall;

        } else  if (grow)
        {
        transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
        grow = !grow;
        runSpeed = runSpeedBig;
        jumpForce = jumpForceBig;
        Gforce = GforceBig;
        SizeState = AlienSizeState.Big;
        Damage = DamageBig;
        }
   }

   void CameraSizeAdjust()
   {
    cam.orthographicSize = camsize;
    if(!grow && camsize < 9f)
        {
            camsize += Time.deltaTime * 20f;
        }

        if (grow && camsize > 3.5f)
        {
            camsize -= Time.deltaTime * 20f;
        }
   }

   public void ColorToGreen()
   {
    ColorState = AlienColorState.Green;
    sprite.sprite = GreenAlien;

    gravity = true;

     if (grow)
        {
        transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
        grow = !grow;
        }

     runSpeed = runSpeedBig;
     jumpForce = jumpForceBig;
     Gforce = GforceBig;
     Damage = DamageBig;
     SizeState = AlienSizeState.Big;
   }

   public void ColorToBlue()
   {
    ColorState = AlienColorState.Blue;
    sprite.sprite = BlueAlien;
    gravity = true;

     if (grow)
        {
        transform.localScale += new Vector3(0.8f, 0.8f, 0.8f);
        grow = !grow;
        }

     runSpeed = runSpeedBig;
     jumpForce = jumpForceBig;
     Gforce = GforceBig;
     Damage = DamageBig;
     SizeState = AlienSizeState.Big;
   }

   public void TakeDamage(int damage)
   {
     Health -= damage;

      if(Health <= 0)
      {
        EventManager.PlayerDeathEvent();
      }
   }

   void Death()
   {
    //Destroy(gameObject);
    Debug.Log("Death");
   }
}
