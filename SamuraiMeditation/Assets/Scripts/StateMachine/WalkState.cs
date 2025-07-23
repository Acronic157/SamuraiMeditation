using UnityEngine;
using UnityEngine.Windows;

public class WalkState : PlayerState
{
    public WalkState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.rb.velocity = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        Player. rb.velocity = new Vector2(Player.xInput * Player.Speed, Player.rb.velocity.y);

        if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift))
        {
            StateMachine.ChangeState(Player.Dash);
        }
        if (Player.xInput == 0)
        {
            StateMachine.ChangeState(Player.Idlestate);
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.ChangeState(Player.Attack);
            Player.rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && Player.GroundCheck)
        {
           
            StateMachine.ChangeState(Player.jump);
        }
        if (!Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.air);
        }
    }
}