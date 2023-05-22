using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorProtectState : EnemyState
{
    private Warrior warrior;
    private D_EnemyProtectState protectData;
    public WarriorProtectState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyProtectState protectData, Warrior warrior) : base(enemy, stateMachine, animBoolName)
    {
        this.warrior = warrior;
        this.protectData = protectData;
    }

    public override void Enter()
    {
        base.Enter();
        IsBlockDrection = true;
        CanChangeState = false;
        ComparePlayerxPosition();
        FlipEnemy();
        warrior.ChangeIdleStateCo(protectData.protectTime);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ComparePlayerxPosition();
        if(warrior.IsFacingRight && xPositionCompare < 0 || !warrior.IsFacingRight && xPositionCompare > 0)
        {
            IsBlockDrection = false;
        }
        else
            IsBlockDrection = true;
    }
}
