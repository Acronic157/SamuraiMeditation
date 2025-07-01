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
        Player.rb.gravityScale = 4f;
        Player.rb.velocity = Vector2.zero;
        
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
            Player.rb.gravityScale = 4f;
        }
        else
        {
            StateMachine.ChangeState(Player.WallSlide);
            Debug.Log("WallSlide");

           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                StateMachine.ChangeState(Player.WallJump);
                Debug.Log("Walljump State activated");
                
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Player.rb.gravityScale = 4f;
            Player.rb.velocity = new Vector2(Player.rb.velocity.x, Player.rb.velocity.y);
            StateMachine.ChangeState(Player.Idlestate);

        }
         Player.xInput = 0;







    }
}
