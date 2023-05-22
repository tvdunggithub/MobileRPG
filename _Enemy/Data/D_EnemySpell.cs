using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newEnemyData", menuName ="Data/Enemy Data/Spell Data")]
public class D_EnemySpell : ScriptableObject
{
    public float spellRadius = 1f;
    public float spellDamage = 50f;
}
