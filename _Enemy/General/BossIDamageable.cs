using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIDamageable : MonoBehaviour, IDamageable
{

    private Enemy _enemy;
    public HpController HpController;

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
            if(_enemy.CurrentHeal < 0)
                _enemy.CurrentHeal = 0;
            _enemy.FloatingDamageText(_enemy.AliveGoTransform.position , attackDetails.DamageAmount.ToString());
            _enemy.ChangeDeadState();
        }
        HpController.ReduceHp(_enemy.CurrentHeal/_enemy.EnemyBaseData.MaxHp);
    }

    public void DamageEffect()
    {
        throw new System.NotImplementedException();
    }
}
