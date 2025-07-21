using UnityEngine;

public class AirState : PlayerState
{

    public bool wallSlideLeft = false;
    public bool wallSlideRight = false;
    
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

        if(Input.GetKey(KeyCode.K) && !Player.WallChecking()&& !Player.WallChecking2() && !Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.Attack);
        }

        if (Player.WallChecking() && Player.rb.velocity.y < 0 && wallSlideRight == false)
        {
            wallSlideRight = true;
            wallSlideLeft = false;
            StateMachine.ChangeState(Player.WallSlide);
        }

        if (Player.WallChecking2() && Player.rb.velocity.y < 0 && wallSlideLeft == false)
        {
            wallSlideRight = false;
            wallSlideLeft = true;
            StateMachine.ChangeState(Player.WallSlide);
        }

        if (Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.Idlestate);
            Player.Particle.Play();
        }

    }
}
