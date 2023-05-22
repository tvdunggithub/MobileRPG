using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyIDamageable : MonoBehaviour, IDamageable
{
    private Enemy _enemy;

    private void Awake() 
    {
        _enemy = GetComponent<Enemy>();
    }
    public void Damage(AttackDetails attackDetails)
    {
        if(_enemy.StateMachine.CurrentState.IsBlockDrection)
            _enemy.FloatingDamageText(_enemy.AliveGoTransform.position , "Block");
        else
        {
            _enemy.CurrentHeal -= attackDetails.DamageAmount;
            _enemy.FloatingDamageText(_enemy.AliveGoTransform.position , attackDetails.DamageAmount.ToString());
            _enemy.ChangeDeadState();
        }
    }

    public void DamageEffect()
    {
    }
}
