using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Player _player;
    private Animator Aim;
    private bool _getHit;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").GetComponent<Player>();
        Aim = GetComponent<Animator>();
    } 

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    public void FixedUpdate()
    {
        if(_getHit)
            _rb.velocity = Vector2.zero;
        else    
            _rb.velocity = _player.SpellDirection * _player.PlayerData.SpellSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            IDamageable iDamageable = other.GetComponentInParent<IDamageable>();
            iDamageable.Damage(_player.SpellAttackDetails);
            _getHit = true;
            Aim.SetBool("exit", true);
            Aim.SetBool("spellEx", true);
        }
    }

    private void AnimationFinished()
    {
        Destroy(gameObject);
    }
}
