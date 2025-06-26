using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState State;

    public void Initialize(PlayerState currentstate)
    {
        State = currentstate;
        State.Enter();
    }

    public void ChangeState(PlayerState newstate)
    {
        State.Exit();
        State = newstate;
        State.Enter();
    }
}
