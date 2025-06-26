using UnityEngine;

public class WallSlideState : PlayerState
{
    private float wallSlideTimer;
    private bool canExitWallSlide;

    public WallSlideState(player _player, PlayerStateMachine _stateMachine, string _aniboolname)
        : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Entered WallSlide");
        wallSlideTimer = 0.2f; // Minimum slide duration
        canExitWallSlide = false;
        Player.SetVelocity(0, -Player.WallSlipSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        // Wall jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("WallJump initiated from slide");
            StateMachine.ChangeState(Player.wallJump);
            return;
        }

        // Timer countdown
        wallSlideTimer -= Time.deltaTime;
        canExitWallSlide = wallSlideTimer <= 0;

        // Maintain slide velocity
        float slideYVelocity = Mathf.Max(-Player.WallSlipSpeed, Player.rb.velocity.y);

        // Wall stick X force
        float stickX = 0;
        if (Mathf.Sign(Player.xInput) == Player.Flip)
        {
            stickX = Player.xInput * 3f;
        }

        Player.SetVelocity(stickX, slideYVelocity);

        // Exit conditions
        if (canExitWallSlide)
        {
            if (Player.GroundCheck())
            {
                StateMachine.ChangeState(Player.Idlestate);
                return;
            }

            if (!Player.IsTouchingWall())
            {
                StateMachine.ChangeState(Player.air);
                return;
            }

            // Moving away from wall
            if (Mathf.Abs(Player.xInput) > 0.1f && Mathf.Sign(Player.xInput) != Player.Flip)
            {
                StateMachine.ChangeState(Player.air);
                return;
            }
        }
    }
}
