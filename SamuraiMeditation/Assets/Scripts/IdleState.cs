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

    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void Update()
    {
        base.Update();
        if(Player.xInput != 0)
        {
            StateMachine.ChangeState(Player.WalkState);
            Debug.Log("I am Still Standing");
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.ChangeState(Player.Attack);
            Player.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }
}
