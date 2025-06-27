using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator animator { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }

    public IdleState Idlestate { get; private set; }
    public WalkState WalkState { get; private set; }
    public Attack Attack { get; private set; }
    public WallSlideState WallSlide { get; private set; }
    public Jump jump { get; private set; }
    public AirState air { get; private set; }
    public WallJump WallJump { get; private set; }

    public float xInput;
    public float Speed;
    public Rigidbody2D rb;

    public bool FlipDirright = true;
    public int Flip = 1;

    public LayerMask Wall;
    public GameObject WallCheck;
    public GameObject GroundDetect;
    public LayerMask Ground;

    public float JumpHeight;
    public float WallSlipSpeed;
    
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        StateMachine = new PlayerStateMachine();
        Idlestate = new IdleState(this, StateMachine, "Idle");
        WalkState = new WalkState(this, StateMachine, "Walk");
        Attack = new Attack(this, StateMachine, "Attack");
        WallSlide = new WallSlideState(this, StateMachine, "WallSlide");
        jump = new Jump(this, StateMachine, "Jump");
        air = new AirState(this, StateMachine, "Jump");
        WallJump = new WallJump(this, StateMachine, "Jump");

        StateMachine.Initialize(Idlestate);
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
        if (!(StateMachine.State is WallSlideState))
        {
            rb.velocity = new Vector2(xInput * Speed, rb.velocity.y);
        }
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

    public void ResetAllAnimBools()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Jump", false);
        animator.SetBool("WallSlide", false);
        animator.SetBool("Attack", false);
    }

    private void OnDrawGizmos()
    {
        if (WallCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(WallCheck.transform.position, WallCheck.transform.position + Vector3.right * 0.5f);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(WallCheck.transform.position, WallCheck.transform.position + Vector3.left * 0.6f );
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(GroundDetect.transform.position, GroundDetect.transform.position + Vector3.down * 1.2f);
    }
}
