using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorProtectState : EnemyState
{
    private Warrior _warrior;
    private D_EnemyProtectState _protectData;
    public WarriorProtectState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyProtectState protectData, Warrior warrior) : base(enemy, stateMachine, animBoolName)
    {
        this._warrior = warrior;
        this._protectData = protectData;
    }

    public override void Enter()
    {
        base.Enter();
        IsBlockDrection = true;
        CanChangeState = false;
        ComparePlayerxPosition();
        FlipEnemy();
        _warrior.ChangeIdleStateCo(_protectData.ProtectTime);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ComparePlayerxPosition();
        if(_warrior.IsFacingRight && _xPositionCompare < 0 || !_warrior.IsFacingRight && _xPositionCompare > 0)
        {
            IsBlockDrection = false;
        }
        else
            IsBlockDrection = true;
    }
}
