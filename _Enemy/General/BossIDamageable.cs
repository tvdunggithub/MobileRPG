using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIDamageable : MonoBehaviour, IDamageable
{

    private Enemy enemy;
    public HpController hpController;

    private void Awake() 
    {
        enemy = GetComponent<Enemy>();
    }

    public void Damage(AttackDetails attackDetails)
    {
        if(enemy.StateMachine.CurrentState.IsBlockDrection)
            enemy.FloatingDamageText(enemy.AliveGO.transform.position , "Block");
        else
        {
            enemy.CurrentHeal -= attackDetails.DamageAmount;
            if(enemy.CurrentHeal < 0)
                enemy.CurrentHeal = 0;
            enemy.FloatingDamageText(enemy.AliveGO.transform.position , attackDetails.DamageAmount.ToString());
            enemy.ChangeDeadState();
        }
        hpController.ReduceHp(enemy.CurrentHeal/enemy.EnemyBaseData.MaxHp);
    }

    public void DamageEffect()
    {
        throw new System.NotImplementedException();
    }
}
