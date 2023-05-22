using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemyIDamageable : MonoBehaviour, IDamageable
{
    private Enemy enemy;
    private Vector3 offSet;

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
            enemy.FloatingDamageText(enemy.AliveGO.transform.position , attackDetails.DamageAmount.ToString());
            enemy.ChangeDeadState();
        }
    }

    public void DamageEffect()
    {
    }
}
