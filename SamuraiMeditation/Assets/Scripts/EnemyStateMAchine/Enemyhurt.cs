using UnityEngine;
using Cinemachine;

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
        enemy.KnockbackTimer = 0.2f;
        
       
        enemy.rb.velocity = Vector3.zero;

        CineMachineShake.Instance.ShakaCamera(5f, 0.3f);
       
    }

    public override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        enemy.KnockbackTimer -= Time.deltaTime;
      

        if (enemy.KnockbackTimer <= 0)
        {
            enemy.rb.velocity = new Vector2(enemy.knockbackeForce * -enemy.Flipdir, 0f);
            return;

        }




    }

    public override void Exit()
    {
        base.Exit();
        
    }

   
}
