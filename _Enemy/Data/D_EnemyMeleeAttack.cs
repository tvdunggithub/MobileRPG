using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEnemyData", menuName ="Data/Enemy Data/Melee Attack Data")]
public class D_EnemyMeleeAttack : ScriptableObject
{
    
    public float AttackRange = 0.5f;
    public float AttackCooldown = 2f;
    public float AttackRadius = 1.1f;
    public float AttackDamage = 50f;
    public Vector2 BoxSize;

}
