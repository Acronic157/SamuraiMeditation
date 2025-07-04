using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private float idleDuration = 3f;
    private float idleTimer;

    public EnemyIdleState(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname)
        : base(_enemy, _enemyStateMachine, _animboolname) { }

    public override void Enter()
    {
        base.Enter();
        idleTimer = idleDuration;
        enemy.rb.velocity = Vector2.zero; // Stop movement
    }

    public override void Update()
    {
        base.Update();

        idleTimer -= Time.deltaTime;

        // Check for player in attack range
        if (enemy.Attacknow)
        {
            enemyStateMachine.Changestate(enemy.Attack);
            return;
        }

        // Transition to Chase if player is detected
        if (enemy.AttackRange || enemy.AttackRangeLeft)
        {
            enemyStateMachine.Changestate(enemy.ChaseState);
            return;
        }

        // Transition to Walk after idle duration
        if (idleTimer <= 0)
        {
            enemyStateMachine.Changestate(enemy.WalkState);
        }
    }
}