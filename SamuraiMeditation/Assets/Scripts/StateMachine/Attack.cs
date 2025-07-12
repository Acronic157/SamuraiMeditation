 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : PlayerState
{
    private bool IsAttacking;
    public Attack(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Collider2D[] hitenemies =  Physics2D.OverlapCircleAll(Player.Attackmid.position, Player.AttackRange, Player.Enemy);

        foreach(Collider2D Enemy in hitenemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(100);
           
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;

    }

    public void AttackStopp()
    {
        IsAttacking = false;
        Player.rb.constraints = RigidbodyConstraints2D.None;
        Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;


        StateMachine.ChangeState(Player.Idlestate);
    }
}
