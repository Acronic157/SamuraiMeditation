using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : PlayerState
{
    public Jump(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname) { }

    public override void Enter()
    {
        base.Enter();
        Player.Particle.Play();
    }

    public override void Exit()
    {
        base.Exit();
       
    }

    public override void Update()
    {
        base.Update();
        
        if (Player.rb.velocity.y < 0)
        {
            StateMachine.ChangeState(Player.air);
        }
    }
}
