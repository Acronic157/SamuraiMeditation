using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    public PlayerStateMachine StateMachine;
    public player Player;
    private string aniboolname;
    


    public PlayerState(player _player,PlayerStateMachine _stateMachine,string _aniboolname)
    {
        StateMachine = _stateMachine;
        Player = _player;
        aniboolname = _aniboolname;
    }

    public virtual void Enter()
    {
       Player.animator.SetBool(aniboolname,true);
    }
    public virtual void Update()
    {

    }

    public virtual void Exit()
    {
        Player.animator.SetBool(aniboolname, false);
    }

}
