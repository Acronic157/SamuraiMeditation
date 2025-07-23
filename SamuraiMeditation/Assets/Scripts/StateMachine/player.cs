using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

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
    public List<Collider2D> IgnoreTheseColliders;
    private Collider2D playerCollider;

    // Attack Range
    public Transform Attackmid;
    public float AttackRange;
    public LayerMask Enemy;

    // Health System for player
    public int maxHealth = 100;
    public int CurrentHealth;

    public ParticleSystem Particle;


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
       
        // Ignore collisions
        if (playerCollider != null && IgnoreTheseColliders != null)
        {
            foreach (Collider2D col in IgnoreTheseColliders)
            {
                if (col != null)
                    Physics2D.IgnoreCollision(playerCollider, col, true);
            }
        }

        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        StateMachine.State.Update();
        FlipController();
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
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
            Flip = 1;
        }
    }

    public void AttackStop()
    {
        Attack.AttackStopp();
    }

   

    public bool WallChecking =>
        Physics2D.Raycast(WallCheck.transform.position, Vector3.right * Flip, 0.3f, Wall);

   public bool GroundCheck =>
        Physics2D.Raycast(GroundDetect.transform.position, Vector2.down, 1.1f, Ground);

    private void OnDrawGizmos()
    {
        if (WallCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(WallCheck.transform.position, WallCheck.transform.position + Vector3.right * Flip * 0.3f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(GroundDetect.transform.position, GroundDetect.transform.position + Vector3.down * 1.1f);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(Attackmid.position, AttackRange);
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
        animator.SetBool("Dead", false);
        Time.timeScale = 0;
    }
}
