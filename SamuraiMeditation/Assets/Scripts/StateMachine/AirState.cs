using UnityEngine;

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

        if (Player.WallChecking()||Player.WallChecking2() && Player.rb.velocity.y < 0)
        {
            StateMachine.ChangeState(Player.WallSlide);
            return;
        }

        if (Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.Idlestate);
        }
    }
}
