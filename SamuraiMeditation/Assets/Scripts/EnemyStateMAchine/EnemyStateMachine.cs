using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState currentstate;

    public void Initialized(EnemyState _currentstate)
    {
        currentstate = _currentstate;
        currentstate.Enter();
    }

    public void Changestate(EnemyState newState)
    {
        currentstate.Exit();
        currentstate = newState;    
        currentstate.Enter();
    }
}
