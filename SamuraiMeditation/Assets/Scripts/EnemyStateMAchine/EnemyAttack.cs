using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname) : base(_enemy, _enemyStateMachine, _animboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(enemy.Attackmid.position,enemy.AttackArea,enemy.Players);
        foreach(Collider2D hitPlayer2 in hitPlayer)
        {
            hitPlayer2.GetComponent<player>().TakeDamage(100);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(!enemy.Attacknow)
        {
            enemyStateMachine.Changestate(enemy.StateIdle);
        }
       
    }
}
