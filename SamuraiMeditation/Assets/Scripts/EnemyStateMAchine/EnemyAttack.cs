using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public float attackTimer;
    public bool hasAttacked;
    private bool animationTriggered = false;

    public EnemyAttack(Enemy _enemy, EnemyStateMachine _enemyStateMachine, string _animboolname) : base(_enemy, _enemyStateMachine, _animboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();

        // Reset attack variables when entering attack state
        attackTimer = 0.2f; 
        hasAttacked = false;
        animationTriggered = false;

        // Make sure animation is not playing at start
        enemy.animator.SetBool("Attack", false);
    }

    public override void Exit()
    {
        base.Exit();
        // Ensure animation is turned off when exiting state
        enemy.animator.SetBool("Attack", false);
    }

    public override void Update()
    {
        base.Update();

        if (!enemy.Attacknow)
        {
            enemyStateMachine.Changestate(enemy.StateIdle);
            return;
        }

        // Count down the attack timer
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else if (!hasAttacked)
        {
            // Trigger animation and attack when timer reaches 0
            enemy.animator.SetBool("Attack", true);
            PerformAttack();
            hasAttacked = true;
            animationTriggered = true;

            // Reset timer for next attack
            attackTimer = 0.2f;
        }
        else if (animationTriggered && !IsAnimationPlaying())
        {
            // When animation finishes, reset for next attack
            enemy.animator.SetBool("Attack", false);
            hasAttacked = false;
            animationTriggered = false;
        }
    }

    private void PerformAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(enemy.Attackmid.position, enemy.AttackArea, enemy.Players);
        foreach (Collider2D hitPlayer2 in hitPlayer)
        {
            hitPlayer2.GetComponent<player>().TakeDamage(100);
        }
    }

    private bool IsAnimationPlaying()
    {
        return enemy.animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") &&
               enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f;
    }
}