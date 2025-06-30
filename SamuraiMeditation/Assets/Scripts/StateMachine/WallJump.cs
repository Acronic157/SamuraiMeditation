using System.Collections;
using UnityEngine;

public class WallJump : PlayerState
{   
    
    // Fabian:
    public float wallJumpXForce = 10f;
    public float wallJumpYForce = 12f;
    public float wallJumpTime = 0.2f;
    public int wallDirection = 0;
    //public bool wallJumpEnded = false;
    public WallJump(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {

    }

    public override void Enter()
    {
        base.Enter();

        // right Wall
        if (Player.WallChecking())
        {
            wallDirection = 1;
        }
        // left Wall
        else if (Player.WallChecking2())
        {
            wallDirection = -1;
        }

    }

    public override void Exit()
    {
        //wallJumpEnded = false;
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        //Debug.Log(wallJumpEnded);

        wallJumpTime -= Time.deltaTime;

        if (wallJumpTime <= 0.0f)
        {
            //wallJumpEnded = true;
            StateMachine.ChangeState(Player.air);
        }

        if (Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.Idlestate);
            Debug.Log("return Idlestate");
        }
        if(Player.WallChecking()||Player.WallChecking2())
        {
           StateMachine.ChangeState(Player.air);
        }

        
        
        Debug.Log("Is in WallJump State");
        Player.rb.gravityScale = 4f;
        Player.rb.velocity = new Vector2(wallDirection * wallJumpXForce, wallJumpYForce);
        //Player.rb.AddForce(new Vector2(wallDirection * wallJumpXForce, wallJumpYForce) * Time.deltaTime);

        
        
    }

   
}