using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
   public Enemy enemy;
   public EnemyStateMachine enemyStateMachine;
   private string animboolname;

    public EnemyState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname)
    {
        enemy = _enemy;
        enemyStateMachine = _enemyStateMachine;
        animboolname = _animboolname;
    }
    
    public virtual void Enter()
    {
        enemy.animator.SetBool(animboolname,true);
    }

    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        enemy.animator.SetBool(animboolname,false); 
    }

}
