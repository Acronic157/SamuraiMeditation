using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public PlayerStateMachine StateMachine {  get; private set; }
    public IdleState IdleState { get; private set; }
    public WalkState WalkState { get; private set; }



    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new IdleState(this, StateMachine, "Idle");
        WalkState = new WalkState(this, StateMachine, "Walk");
    }
}
