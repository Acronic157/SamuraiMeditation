using System.Collections;
using UnityEngine;

public class WallJump : PlayerState
{
    public WallJump(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.StartCoroutine(WallJumpRoutine());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

    private IEnumerator WallJumpRoutine()
    {
        // Apply jump force away from wall
        float jumpDirection = -Player.Flip;
        Player.SetVelocity(Player.WallJumpCoolDown * jumpDirection, Player.JumpHeight);

        // Flip player to face jump direction
        if ((jumpDirection > 0 && !Player.FlipDirright) || (jumpDirection < 0 && Player.FlipDirright))
        {
            Player.FlipThePlayer();
        }

        // Wait for jump duration
        yield return new WaitForSeconds(0.2f);

        // Transition to air state
        StateMachine.ChangeState(Player.air);
    }
}