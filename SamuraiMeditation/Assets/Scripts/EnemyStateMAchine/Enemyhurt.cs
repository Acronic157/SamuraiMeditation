using UnityEngine;

public class Enemyhurt : EnemyState
{
    private float hurtDuration = 1f;
    private float timer;

    public Enemyhurt(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname)
        : base(_enemy, _enemyStateMachine, _animboolname) { }

    public override void Enter()
    {
        base.Enter();
        timer = hurtDuration;
        enemy.rb.velocity = Vector2.zero;
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            enemy.StateMachine.Changestate(enemy.StateIdle);
        }
    }

    public override void Exit()
    {
        base.Exit();
        
    }
}
