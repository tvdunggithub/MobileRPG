using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStateMachine : MonoBehaviour
{
    public EnemyAttackState AttackState;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    private void TriggerAttack()
    {
        AttackState.TriggerAttack();
    }

    private void FinishAttack()
    {
        AttackState.FinishAttack();
    }

    private void AnimationFinished()
    {
        enemy.StateMachine.CurrentState.isAnimationFinished = true;
    }
}
