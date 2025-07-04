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

        // Update direction every frame
        Vector3 direction = (enemy.Player_GameObject.transform.position - enemy.transform.position).normalized;
        enemy.Direction = direction;

        // Smooth chase movement
        float targetVelocityX = enemy.Direction.x * enemy.Chasespeed;
        float smoothedVelocityX = Mathf.Lerp(enemy.rb.velocity.x, targetVelocityX, Time.deltaTime * 5f);
        enemy.rb.velocity = new Vector2(smoothedVelocityX, enemy.rb.velocity.y);

        // Transition to Attack if in range
        if (enemy.Attacknow)
        {
            enemyStateMachine.Changestate(enemy.Attack);
            return;
        }

        // Return to Idle if player is out of range
        if (!enemy.AttackRange && !enemy.AttackRangeLeft)
        {
            enemyStateMachine.Changestate(enemy.StateIdle);
            return;
        }
    }
}