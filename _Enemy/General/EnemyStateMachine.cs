using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public void Initialize(EnemyState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState newState)
    {
        if(!CurrentState.CanChangeState && !newState.IsDeadState())
            return;
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
