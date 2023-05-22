using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEnemyData", menuName ="Data/Enemy Data/Throwing Data")]
public class D_EnemyRangedData : ScriptableObject
{
    public float projectileSpeed;
    public float activeTime;
    public float shootingTime;
    public float throwingTime;
    public GameObject projectilePrefab;
    public float AttackDamage;
}
