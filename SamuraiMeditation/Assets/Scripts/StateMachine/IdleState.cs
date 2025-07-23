// using System.Numerics;
using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Player.rb.isKinematic = true;
        //layer.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        //Player.rb.velocity = new Vector2(0, Player.rb.velocity.y);

    }

    public override void Exit()
    {
        base.Exit();
        //Player.rb.isKinematic = false;
        //Player.rb.constraints = RigidbodyConstraints2D.None;
        //Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public override void Update()
    {
        base.Update();
        //Player.rb.velocity = new Vector2(0, Player.rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StateMachine.ChangeState(Player.Dash);
        }
        if (Player.xInput != 0 && Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.WalkState);
        }
        else if (Player.xInput != 0 && !Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.air);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.ChangeState(Player.Attack);
            Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Player.GroundCheck)
        {
           
            StateMachine.ChangeState(Player.jump);
        }
    }
}