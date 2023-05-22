using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemProjectile : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Goblem _goblem;
    
    public D_EnemyRangedData _throwingData;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _goblem = transform.parent.GetComponent<Goblem>();     
    }

    private void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        _rb.velocity = _goblem.ShootDirection * _throwingData.ProjectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerDamageable playerDamageable = other.GetComponent<PlayerDamageable>();
            playerDamageable.Damage(_goblem._attackDetails);
        }
    }
}
