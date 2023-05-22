using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEnemyData", menuName ="Data/Enemy Data/Base Data")]
public class D_EnemyBase : ScriptableObject
{
    public float playerDetectedRadius;
    public LayerMask whatIsPlayer;
    public float MaxHp;
}
