using System.Collections;
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
    public WallJump wallJump { get; private set; }

    public float xInput;
    public float Speed;
    public Rigidbody2D rb;

    public bool FlipDirright = true;
    public int Flip = 1;

    public LayerMask Wall;
    public GameObject WallCheck;
    public LayerMask Ground;

    public float JumpHeight;
    public float WallSlipSpeed;
    public float Jump;
    public float WallJumpCoolDown;

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
        wallJump = new WallJump(this, StateMachine, "Jump");

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
        rb.velocity = new Vector2(xInput * Speed, rb.velocity.y);
    }

    public void FlipThePlayer()
    {
        FlipDirright = !FlipDirright;
        Flip = FlipDirright ? 1 : -1;
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

    public bool IsTouchingWall()
    {
        Vector3 direction = FlipDirright ? Vector3.right : Vector3.left;
        return Physics2D.Raycast(WallCheck.transform.position, direction, 0.5f, Wall);
    }

    public bool GroundCheck() =>
        Physics2D.Raycast(transform.position, Vector2.down, 1f, Ground);

    private void OnDrawGizmos()
    {
        if (WallCheck == null) return;

        Gizmos.color = Color.green;
        Vector3 dir = FlipDirright ? Vector3.right : Vector3.left;
        Gizmos.DrawLine(WallCheck.transform.position, WallCheck.transform.position + dir * 0.5f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1f);
    }
}
