using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator animator {  get; private set; }
    public PlayerStateMachine StateMachine {  get; private set; }
    public IdleState Idlestate { get; private set; }
    public WalkState WalkState { get; private set; }
    public Attack Attack { get; private set; }


    //Run
    public float xInput;
    public float Speed;
    public Rigidbody2D rb;

    //Flip
    public bool FlipDirright = true;
    public int Flip = 1;

   



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        StateMachine = new PlayerStateMachine();
        Idlestate = new IdleState(this, StateMachine, "Idle");
        WalkState = new WalkState(this, StateMachine, "Walk");
        StateMachine.Initialize(Idlestate);
        Attack = new Attack(this,StateMachine,"Attack");
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        Run();
        StateMachine.State.Update();
        FlipController();
    }

    public void Run()
    {
        xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(xInput * Speed , rb.velocity.y);  
    }

    public void FlipThePlayer()
    {
        FlipDirright = !FlipDirright;
        Flip = -1;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController()
    {
        if(xInput < 0 && FlipDirright)
        {
            FlipThePlayer();
        }
        else if(xInput > 0 && !FlipDirright)
        {
            FlipThePlayer();
        }
    }

    public void AttackStop()
    {
        Attack.AttackStopp();
    }
}
