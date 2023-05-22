using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemPlayerDetectedState : EnemyPlayerDetectedState
{
    private Goblem goblem;
    private Color c1 = Color.white;
    private Vector3[] vector3 = { Vector3.zero, Vector3.zero };

    public GoblemPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyPlayerDetected enemyPlayerDetectedData, Goblem goblem) : base(enemy, stateMachine, animBoolName, enemyPlayerDetectedData)
    {
        this.goblem = goblem;
    }

    public override void Enter()
    {
        base.Enter();
        goblem.IsAimTimeFinish = false;
        goblem.StartAim(enemyPlayerDetectedData.agrroTime);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        AimLogic();
    }

    public void DrawWhiteLaze()
    {
        goblem.LineRenderer.startColor = c1;
        goblem.LineRenderer.endColor = c1;
        goblem.LineRenderer.SetPositions(new Vector3[] {goblem.ProjectileTransform.position, goblem.Player.transform.position});
    }

    public void RemoveLaze()
    {
        vector3[0] = Vector3.zero;
        vector3[1] = Vector3.zero;
        goblem.LineRenderer.SetPositions(vector3);
    }

    public void AimLogic()
    {
        if(enemy.Player == null)
        {
            goblem.StateMachine.ChangeState(goblem.IdleState);
            RemoveLaze();
        }else         
        {
            ComparePlayerxPosition();
            FlipEnemy();
            if(!goblem.IsAimTimeFinish)
                DrawWhiteLaze();
            else 
                StateMachine.ChangeState(goblem.ThrowingState);
        }
    }

}
