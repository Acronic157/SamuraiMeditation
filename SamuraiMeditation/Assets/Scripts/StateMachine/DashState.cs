using UnityEngine;

public class DashState : PlayerState
{
    private Vector2 dashDirection;

    public DashState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.dashTimer = Player.dashDuration;
        Player.isDashing = true;

        // Determine dash direction based on facing direction (more precise)
        dashDirection = Player.FlipDirright ? Vector2.right : Vector2.left;

        // Immediately apply dash velocity
        Player.rb.velocity = dashDirection * Player.DashSpeed;
        Player.rb.gravityScale = 0f;

        // Debug to verify direction
        Debug.Log("Dashing direction: " + dashDirection);
    }

    public override void Exit()
    {
        base.Exit();
        Player.isDashing = false;
        Player.rb.gravityScale = 4f;

        // Apply end speed in dash direction
        Player.rb.velocity = new Vector2(dashDirection.x * Player.dashEndSpeed, 0);
    }

    public override void Update()
    {
        base.Update();
        Player.dashTimer -= Time.deltaTime;

        if (Player.dashTimer <= 0)
        {
            StateMachine.ChangeState(Player.Idlestate);
        }
    }
}