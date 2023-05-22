using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine 
{
    public PlayerState CurrentState { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        if(!CurrentState.CanChangeState)
            return;
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }

    public void ChangeDeadState(PlayerDeadState deadState)
    {
        CurrentState.Exit();
        CurrentState = deadState;
        CurrentState.Enter();
    }
}
