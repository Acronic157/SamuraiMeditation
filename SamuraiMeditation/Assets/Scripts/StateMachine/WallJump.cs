using System.Collections;
using UnityEngine;

public class WallJump : PlayerState
{
    private float WallJumpTimer = 0.2f;
    public WallJump(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.SetVelocity(8 * -Player.Flip, Player.JumpHeight);
        Player.FlipThePlayer();


    }

    public override void Update()
    {
        base.Update();
        WallJumpTimer -= Time.deltaTime;
        if(WallJumpTimer < 0)
        {
            StateMachine.ChangeState(Player.air);
            WallJumpTimer = 0.2f;
        }

        if(Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.Idlestate);
        }

       
       
       
    }

    public override void Exit()
    {
        base.Exit();
       
    }
}
