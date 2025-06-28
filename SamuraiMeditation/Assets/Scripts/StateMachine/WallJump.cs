using System.Collections;
using UnityEngine;

public class WallJump : PlayerState
{   
    
    // Fabian:
    public float wallJumpXForce = 10f;
    public float wallJumpYForce = 12f;
    public WallJump(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {

    }

    public override void Enter()
    {
        base.Enter();

        //Fabian
        int wallDirection = 1;
        Debug.Log("Is in WallJump State");
        Player.rb.gravityScale = 4f;
        Player.rb.velocity = new Vector2(wallDirection * wallJumpXForce, wallJumpYForce);
        Player.rb.AddForce(new Vector2(wallDirection * wallJumpXForce, wallJumpYForce) * Time.deltaTime);
        // If wallcheck -> WallSlide State

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.Idlestate);
            Debug.Log("return Idlestate");
        }

        
    }

   
}