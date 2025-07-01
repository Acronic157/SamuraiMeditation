using System.Collections;
using UnityEngine;

public class WallJump : PlayerState
{
    private float wallJumpTimer = 0.2f;
    private bool jumpApplied = false;
    private int wallDirection = 0;

    public float wallJumpXForce = -50f;
    public float wallJumpYForce = 25f;

    public WallJump(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();

        wallJumpTimer = 0.2f;
        jumpApplied = false;

        // Determine wall direction and flip
        if (Player.WallChecking())
        {
            wallDirection = 1;
           
            
        }
        else if (Player.WallChecking2())
        {
            wallDirection = -1;
           
           
        }

        Player.rb.gravityScale = 4f;

        // Apply the jump force only once
        Player.rb.velocity = new Vector2(wallDirection * wallJumpXForce, wallJumpYForce);
        jumpApplied = true;
        Debug.Log("Wall Jump Applied");
    }

    public override void Update()
    {
        base.Update();

        wallJumpTimer -= Time.deltaTime;

        if (wallJumpTimer <= 0f)
        {
            StateMachine.ChangeState(Player.air);
        }

        if (Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.Idlestate);
        }
       
       
    }

    public override void Exit()
    {
        base.Exit();
        jumpApplied = false;
    }
}
