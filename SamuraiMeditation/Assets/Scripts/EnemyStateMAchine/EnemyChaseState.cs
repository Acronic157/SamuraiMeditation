using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public EnemyChaseState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname)
        : base(_enemy, _enemyStateMachine, _animboolname) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        // Direction to player
        Vector3 directionToPlayer = (enemy.Player_GameObject.transform.position - enemy.transform.position).normalized;
        enemy.Direction = directionToPlayer;

        // Smooth chase movement
        float targetVelocityX = enemy.Direction.x * enemy.Chasespeed;
        float smoothedVelocityX = Mathf.Lerp(enemy.rb.velocity.x, targetVelocityX, Time.deltaTime * 5f);
        enemy.rb.velocity = new Vector2(smoothedVelocityX, enemy.rb.velocity.y);

        // Flip only if needed based on direction to player
        if (enemy.Direction.x < 0 && !enemy.Facingright)
        {
            enemy.Flip();
            enemy.Flipdir = -1;
        }
        else if (enemy.Direction.x > 0 && enemy.Facingright)
        {
            enemy.Flip();
            enemy.Flipdir = 1;
        }

       

        // Transition to Attack
        if (enemy.Attacknow)
        {
            enemyStateMachine.Changestate(enemy.StateIdle);
            return;
        }

        // Return to Idle if player is out of detection range
        if (!enemy.AttackRange && !enemy.AttackRangeLeft)
        {
          
            enemyStateMachine.Changestate(enemy.StateIdle);
            return;
        }
    }
}
