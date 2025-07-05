using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    // State Components
    public Animator animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    // States
    public IdleState Idlestate { get; private set; }
    public WalkState WalkState { get; private set; }
    public Attack Attack { get; private set; }
    public WallSlideState WallSlide { get; private set; }
    public Jump jump { get; private set; }
    public AirState air { get; private set; }
    public WallJump WallJump { get; private set; }
    public Dead dead { get; private set; }
    public DashState Dash { get; private set; }

    // Movement
    public float xInput;
    public float Speed;
    public Rigidbody2D rb;
   

    // Flipping
    public bool FlipDirright = true;
    public int Flip = 1;

    // Collision Detection
    public LayerMask Wall;
    public GameObject WallCheck;
    public GameObject GroundDetect;
    public LayerMask Ground;

    // Physics
    public float JumpHeight;
    public float WallSlipSpeed;

    // Ignore Collision
    public GameObject Ignorecol;
    private Collider2D playerCollider;

    //Attack Range
    public Transform Attackmid;
    public float AttackRange;
    public LayerMask Enemy;

    //Health System for player
    public int maxHealth = 100;
    public int CurrentHealth;
    //Dash 
    public float DashSpeed = 20f;
    public float dashDuration = 0.5f;
    public float DashCoolDown = 1f;
    public float dashEndSpeed = 5f;
    [HideInInspector] public float dashTimer;
    [HideInInspector] public bool isDashing;
    public float normalGravityScale = 3f;

    private void Awake()
    {
        // Get components
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();

        // Initialize state machine
        StateMachine = new PlayerStateMachine();
        Idlestate = new IdleState(this, StateMachine, "Idle");
        WalkState = new WalkState(this, StateMachine, "Walk");
        Attack = new Attack(this, StateMachine, "Attack");
        WallSlide = new WallSlideState(this, StateMachine, "WallSlide");
        jump = new Jump(this, StateMachine, "Jump");
        air = new AirState(this, StateMachine, "Jump");
        WallJump = new WallJump(this, StateMachine, "Jump");
        dead = new Dead(this, StateMachine, "Dead");
        Dash = new DashState(this, StateMachine, "Dash");


        StateMachine.Initialize(Idlestate);
    }

    private void Start()
    {
       
        if (Ignorecol != null)
        {
            Collider2D ignoreCollider = Ignorecol.GetComponent<Collider2D>();
            if (playerCollider != null && ignoreCollider != null)
            {
                Physics2D.IgnoreCollision(playerCollider, ignoreCollider, true);
            }
           
        }

        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        Run();
        StateMachine.State.Update();
        FlipController();
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
        FlipController();
    }

    public void Run()
    {
        xInput = Input.GetAxis("Horizontal");
        if (!(StateMachine.State is WallSlideState) && !isDashing) // Add !isDashing check
        {
            rb.velocity = new Vector2(xInput * Speed, rb.velocity.y);
        }
    }
    public bool CanDash()
    {
        return GroundCheck() && !isDashing;
    }


    public void FlipThePlayer()
    {
        FlipDirright = !FlipDirright;
        Flip *= -1;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController()
    {
        if (xInput < 0 && FlipDirright)
        {
            FlipThePlayer();
        }
        else if (xInput > 0 && !FlipDirright)
        {
            FlipThePlayer();
        }
    }

    public void AttackStop()
    {
        Attack.AttackStopp();
    }

    public bool WallChecking() =>
        Physics2D.Raycast(WallCheck.transform.position, Vector3.right, 0.5f, Wall);

    public bool WallChecking2() =>
        Physics2D.Raycast(WallCheck.transform.position, Vector3.left, 0.6f, Wall);

    public bool GroundCheck() =>
        Physics2D.Raycast(GroundDetect.transform.position, Vector2.down, 1.2f, Ground);

   

    private void OnDrawGizmos()
    {
        if (WallCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(WallCheck.transform.position, WallCheck.transform.position + Vector3.right * 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(WallCheck.transform.position, WallCheck.transform.position + Vector3.left * 0.6f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(GroundDetect.transform.position, GroundDetect.transform.position + Vector3.down * 1.2f);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Attackmid.position,AttackRange);
    }

    public void TakeDamage(int Damage)
    {
        CurrentHealth -= Damage;
        if (CurrentHealth <= 0)
        {
            StateMachine.ChangeState(dead);
           
        }

    }
        public void Stopanim()
        {
          animator.SetBool("Dead",false);
         Time.timeScale = 0;


        }

   

}