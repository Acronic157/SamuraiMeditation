using UnityEngine;

public class WalkState : PlayerState
{
    public WalkState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift) && Player.CanDash())
        {
            StateMachine.ChangeState(Player.Dash);
        }
        if (Player.xInput == 0)
        {
            StateMachine.ChangeState(Player.Idlestate);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.ChangeState(Player.Attack);
            Player.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Player.GroundCheck())
        {
            Player.rb.velocity = new Vector2(0, Player.JumpHeight);
            StateMachine.ChangeState(Player.jump);
        }
        if (!Player.GroundCheck())
        {
            StateMachine.ChangeState(Player.air);
        }
    }
}