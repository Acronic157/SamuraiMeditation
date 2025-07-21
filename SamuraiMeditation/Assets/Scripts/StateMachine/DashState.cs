using UnityEngine;

public class DashState : PlayerState
{
    private float DashDuration = 0.2f;
    private float DashSpeed = 20f;


    public DashState(player _player, PlayerStateMachine _stateMachine, string _aniboolname) : base(_player, _stateMachine, _aniboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
       

       
       
    }

    public override void Exit()
    {
        base.Exit();
        Player.rb.velocity = Vector2.zero;
      
    }

    public override void Update()
    {
        base.Update();

        Player.rb.velocity = new Vector2(DashSpeed * Player.Flip, 0f);


        DashDuration -= Time.deltaTime;

        if ( DashDuration <= 0 )
        {
            StateMachine.ChangeState(Player.Idlestate);
            DashDuration = 0.2f;
        }
        
    }
}