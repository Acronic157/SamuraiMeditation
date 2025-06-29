using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    
    public EnemyIdleState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname) : base(_enemy, _enemyStateMachine, _animboolname)
    {

    }

    public override void Enter()
    {
        base.Enter();
        enemy.StartCoroutine(changeDetect());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.StartCoroutine(changeDetect());
       

       
    }

    public IEnumerator changeDetect()
    {
        yield return new WaitForSeconds(3);
        enemyStateMachine.Changestate(enemy.WalkState);
    }
    

   
}
