using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemProjectile : MonoBehaviour
{

    private Rigidbody2D rb;
    private Goblem goblem;
    
    public D_EnemyRangedData throwingData;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        goblem = transform.parent.GetComponent<Goblem>();     
    }

    private void Update()
    {
        
    }
    private void FixedUpdate() 
    {
        rb.velocity = goblem.ShootDirection * throwingData.projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerDamageable playerDamageable = other.GetComponent<PlayerDamageable>();
            playerDamageable.Damage(goblem._attackDetails);
        }
    }
}
