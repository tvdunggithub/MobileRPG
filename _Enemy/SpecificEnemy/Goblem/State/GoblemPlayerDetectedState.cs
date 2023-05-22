using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemPlayerDetectedState : EnemyPlayerDetectedState
{
    private Goblem _goblem;
    private Color _c1 = Color.white;
    private Vector3[] _vector3 = { Vector3.zero, Vector3.zero };

    public GoblemPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyPlayerDetected enemyPlayerDetectedData, Goblem goblem) : base(enemy, stateMachine, animBoolName, enemyPlayerDetectedData)
    {
        this._goblem = goblem;
    }

    public override void Enter()
    {
        base.Enter();
        _goblem.IsAimTimeFinish = false;
        _goblem.StartAim(_enemyPlayerDetectedData.AgrroTime);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        AimLogic();
    }

    public void DrawWhiteLaze()
    {
        _goblem.LineRenderer.startColor = _c1;
        _goblem.LineRenderer.endColor = _c1;
        _goblem.LineRenderer.SetPositions(new Vector3[] {_goblem.ProjectileTransform.position, _goblem.Player.Transform.position});
    }

    public void RemoveLaze()
    {
        _vector3[0] = Vector3.zero;
        _vector3[1] = Vector3.zero;
        _goblem.LineRenderer.SetPositions(_vector3);
    }

    public void AimLogic()
    {
        if(_enemy.Player == null)
        {
            _goblem.StateMachine.ChangeState(_goblem.IdleState);
            RemoveLaze();
        }else         
        {
            ComparePlayerxPosition();
            FlipEnemy();
            if(!_goblem.IsAimTimeFinish)
                DrawWhiteLaze();
            else 
                StateMachine.ChangeState(_goblem.ThrowingState);
        }
    }

}
