using UnityEngine;

public class EnemyWalkState : EnemyState
{
    public EnemyWalkState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname) 
        : base(_enemy, _enemyStateMachine, _animboolname) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        // Smooth movement
        float targetVelocityX = enemy.Speed * enemy.Flipdir;
        float smoothedVelocityX = Mathf.Lerp(enemy.rb.velocity.x, targetVelocityX, Time.deltaTime * 5f);
        enemy.rb.velocity = new Vector2(smoothedVelocityX, enemy.rb.velocity.y);

        // Check for walls/obstacles
        if (enemy.WallCheck)
        {
            enemy.Flip();
            enemy.Flipdir = -1;
            enemyStateMachine.Changestate(enemy.StateIdle);
            return;
        }
        if(enemy.ObjectCheck)
        {
            enemy.Flip();
            enemy.Flipdir = 1;
            enemyStateMachine.Changestate(enemy.StateIdle);
        }
        if(!enemy.GroundCheck)
        {
            enemy.Flip();
            enemyStateMachine.Changestate(enemy.StateIdle);
            return;
        }

        // Transition to Chase if player is detected
        if (enemy.AttackRange || enemy.AttackRangeLeft)
        {
            enemyStateMachine.Changestate(enemy.ChaseState);
            return;
        }
       
    }
}