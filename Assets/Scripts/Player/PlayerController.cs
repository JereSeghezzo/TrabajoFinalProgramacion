using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerController : MonoBehaviour,ITakeDamage
{
    public enum AlienColorState{Green, Blue};
    public enum AlienSizeState{Small, Big};

    public AlienColorState ColorState;
    public AlienSizeState SizeState;

    [HideInInspector] public float runSpeed;
    [HideInInspector] public float jumpForce;

    [Header("Health")]
    [Range(0, 10)]
    [SerializeField] private int Health;
    
    [Header("Death")]
    public GameObject particles;

    [HideInInspector]public int Damage;

    [Header("HitCoolDown")]
    public float stunCoolDown;
    float stunCD;
    [HideInInspector] public bool stunned;

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
    [SerializeField] private int DamageMultiplier;
    

    [HideInInspector] public bool IsGrounded;
    [HideInInspector] public bool change;

    [Header("Ability Cool Down")]
    [SerializeField] private float AbilityCD;
    private float _abilityCD;

    private float camsize = 9;

    bool grow;
    [HideInInspector] public bool gravity;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public SpriteRenderer sprite;
    [HideInInspector]Animator animator;

    [Header("Camera")]
    public CinemachineVirtualCamera cam;

    [Header("Alien Sprites")]
    public Sprite GreenAlien;
    public Sprite BlueAlien;

    [Header("Animator Controller")]
    public RuntimeAnimatorController BlueAnimation;
    public RuntimeAnimatorController GreenAnimation;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        EventManager.GameOverEvent += Death;
        EventManager.WinEvent += Win;

        Gforce = GforceBig;
        camsize = 9;
        runSpeed = runSpeedBig;
        jumpForce = jumpForceBig;
        gravity = true;
        _abilityCD = AbilityCD;

        ColorState = AlienColorState.Blue;
        SizeState = AlienSizeState.Big;
 
      animator.runtimeAnimatorController = BlueAnimation;    
    }

    void FixedUpdate()
    {
      rb.AddForce(transform.up * -Gforce * 2f);
      HitCD();
    }

    void Update()
    {

      Health = Mathf.Clamp(Health, 0 , 10);

     if(_abilityCD < AbilityCD)
     {
      _abilityCD += Time.deltaTime;
     }    
    
    if(!stunned)
    {
     Movement();
    }
  
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

      if(Input.GetKey("d") || Input.GetKey("a"))
      {
         animator.SetBool("Walking", true);
      }else 
      {
         animator.SetBool("Walking", false);
      }
    }

    public void Movement()
    {

      if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            sprite.flipX = false;
        }

        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            sprite.flipX = true;
        }
        else
        {
           rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (Input.GetKeyDown("space") && IsGrounded == true)
        {
            rb.AddForce(transform.up * jumpForce * 100);
            IsGrounded = false;
            animator.SetBool("Jumping", true); 
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
    cam.m_Lens.OrthographicSize = camsize;
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
    animator.runtimeAnimatorController = GreenAnimation;
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
    animator.runtimeAnimatorController = BlueAnimation;
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
    if(!stunned)
    {
     animator.SetBool("Hit", true); 
     StartCoroutine(FlashRed());
     if(SizeState == PlayerController.AlienSizeState.Big)
     {
      Health -= damage;
     }else  if(SizeState == PlayerController.AlienSizeState.Small)
     {
      Health -= damage * DamageMultiplier;
     }
     stunned = true;
    }

      if(Health <= 0)
      {
        EventManager.PlayerDeathEvent();
      }
   }

   void Death()
   {
    Instantiate(particles, transform.position, transform.rotation);
    Destroy(gameObject);
   }

   void Win()
   {
    print("Victory");
   }

   void HitCD()
   {
    if(stunCD < stunCoolDown && stunned)
    {
      stunCD += Time.deltaTime;
      if(stunCD >= stunCoolDown)
      {
        stunned = false;
        animator.SetBool("Hit", false);
      }
    }

    if(stunned == false)
    {
      stunCD = 0f;
    }
   }

   public IEnumerator FlashRed()
 {
    sprite.color = Color.red;
    yield return new WaitForSeconds(0.1f);
    sprite.color = Color.white;
 }
}
