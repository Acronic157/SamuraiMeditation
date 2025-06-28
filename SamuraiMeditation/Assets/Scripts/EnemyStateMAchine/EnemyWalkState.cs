using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkState : EnemyState
{
    public EnemyWalkState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname) : base(_enemy, _enemyStateMachine, _animboolname)
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

        enemy.rb.velocity = new Vector2(enemy.Speed * enemy.Flipdir, enemy.rb.velocity.y);

        if(enemy.WallCheck)
        {
            enemy.Flip();
           enemy.Flipdir = 1;
            enemyStateMachine.Changestate(enemy.StateIdle);

            enemy.rb.velocity = Vector2.zero;
        }

        if(!enemy.GroundCheck)
        {
           
            enemyStateMachine.Changestate(enemy.StateIdle);
            enemy.Flip();
            enemy.rb.velocity = Vector2.zero;
        }
        
    }
}
