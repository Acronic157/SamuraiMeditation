using System;
using UnityEngine;

public class WallSlideState : PlayerState
{


    public WallSlideState(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
      
    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            StateMachine.ChangeState(Player.WallJump);
            return;
        }

        Player.rb.velocity = new Vector2(0, Player.rb.velocity.y * 0.7f);

        if (Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.Idlestate);
           
        }
        
        if(Player.xInput != 0 && Player.Flip != Player.xInput)
        {
            StateMachine.ChangeState(Player.Idlestate);
        }

        if(Player.xInput != 0 && Player.Flip == Player.xInput)
        {
            StateMachine.ChangeState(Player.WallSlide);
        }

        else if(Player.WallChecking == false)
        {
            StateMachine.ChangeState(Player.air);
        }

        if (Player.xInput != 0 && !Player.WallChecking) { StateMachine.ChangeState(Player.Idlestate); }

    }
}
