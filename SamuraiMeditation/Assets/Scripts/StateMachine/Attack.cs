using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : PlayerState
{
    private bool IsAttacking;
    public Attack(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
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

        
    }

    public void AttackStopp()
    {
        IsAttacking = false;
        Player.rb.constraints = RigidbodyConstraints2D.None;
        Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        StateMachine.ChangeState(Player.Idlestate);
    }
}
