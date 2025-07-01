using System.Collections;
using UnityEngine;

public class WallJump : PlayerState
{
    private float wallJumpTimer = 0.2f;
    private bool jumpApplied = false;
    private int wallDirection = 0;

    public float wallJumpXForce = 0f;
    public float wallJumpYForce = 15f;

    public WallJump(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();

        wallJumpTimer = 0.1f;
        jumpApplied = false;

        // Wandrichtung eindeutig bestimmen
        if (Player.WallChecking() && !Player.WallChecking2())
            wallDirection = -1;
        else if (Player.WallChecking2() && !Player.WallChecking())
            wallDirection = 1;
        else
            wallDirection = Player.Flip; // Fallback, falls keine Wand erkannt

        Player.rb.gravityScale = 4f;

        // Velocity nur einmal setzen
        Player.rb.velocity = new Vector2(wallDirection * wallJumpXForce, wallJumpYForce);
        jumpApplied = true;
        Debug.Log("Wall Jump Applied, wallDirection: " + wallDirection + ", velocity: " + Player.rb.velocity);
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
