using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname) : base(_enemy, _enemyStateMachine, _animboolname)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        enemy.Speed = 2;
    }

    public override void Update()
    {
        base.Update();
        enemy.Speed = 0;
        enemy.rb.velocity = new Vector2(enemy.Chasespeed * enemy.Flipdir,enemy.rb.velocity.y);
        if (!enemy.AttackRange)
        {
            enemy.rb.velocity = Vector2.zero;
            enemyStateMachine.Changestate(enemy.StateIdle);

        }
        if (enemy.Attacknow)
        {
            enemyStateMachine.Changestate(enemy.Attack);
        }
    }
}
