using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    public float MoveSpeed = 5f;
    public float DashTime = 0.1f;
    public float DashSpeed = 50f;
    public float DashCoolDown = 2f;
    public Vector2 AttackCapsuleSize;
    public LayerMask WhatIsEnemy;
    public float DamageAmount = 50f;
    public float HP = 200f;
    public float ChangeColorTime = 0.2f;
    public float TwinklingTime = 2f;
    public float SpellCooldown = 3f;
    public float SpellSpeed = 8f;
    public float SpellDamage = 100f;
    public float EnemyCheckRadius = 8f;
}
