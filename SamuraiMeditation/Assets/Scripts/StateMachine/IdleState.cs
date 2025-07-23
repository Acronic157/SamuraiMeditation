using UnityEngine;

public class IdleState : PlayerState
{
    public IdleState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
       

    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StateMachine.ChangeState(Player.Dash);
        }
        if (Player.xInput != 0 && Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.WalkState);
        }
        else if (Player.xInput != 0 && !Player.GroundCheck)
        {
            StateMachine.ChangeState(Player.air);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StateMachine.ChangeState(Player.Attack);
            Player.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        if (Input.GetKeyDown(KeyCode.Space) && Player.GroundCheck)
        {
           
            StateMachine.ChangeState(Player.jump);
        }
    }
}