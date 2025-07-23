using UnityEngine;
using UnityEngine.Windows;

public class AirState : PlayerState
{

   
    
    public AirState(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Player.WallChecking)
        {
            StateMachine.ChangeState(Player.WallSlide);
        }

        if(UnityEngine.Input.GetKey(KeyCode.K) && !Player.WallChecking&& !Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.Attack);
        }

        if (Player.xInput != 0)
        {
            Player.rb.velocity = new Vector2(Player.Speed * Player.xInput, Player.rb.velocity.y);
        }



        if (Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.Idlestate);
            Player.Particle.Play();
        }

    }
}
