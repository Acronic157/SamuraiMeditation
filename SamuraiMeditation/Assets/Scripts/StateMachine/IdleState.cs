using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{



    public IdleState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }



    public override void Enter()
    {
        base.Enter();
        Player.air.wallSlideLeft = false;
        Player.air.wallSlideRight = false;

    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void Update()
    {
        base.Update();

        if (Player.rb.velocity.y > 0)
        {
            StateMachine.ChangeState(Player.air);
        }

        if (Player.xInput != 0 && Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.WalkState);

        }

        else if (Player.xInput != 0 && !Player.GroundCheck())
        {
            //Debug.Log("It worked");
            StateMachine.ChangeState(Player.air);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.ChangeState(Player.Attack);

            Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }


        if (Input.GetKeyDown(KeyCode.Space) && Player.GroundCheck())
        {

            //Debug.Log("Jump pressed");
            Player.rb.velocity = new Vector2(0, Player.JumpHeight);
           
            StateMachine.ChangeState(Player.jump);
       
    }   }
}
