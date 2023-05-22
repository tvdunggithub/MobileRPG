using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEnemyData", menuName ="Data/Enemy Data/Throwing Data")]
public class D_EnemyRangedData : ScriptableObject
{
    public float ProjectileSpeed;
    public float ActiveTime;
    public float ShootingTime;
    public float ThrowingTime;
    public GameObject ProjectilePrefab;
    public float AttackDamage;
}
