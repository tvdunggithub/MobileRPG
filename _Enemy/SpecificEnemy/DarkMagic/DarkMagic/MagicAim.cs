using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAim : MonoBehaviour
{

    private Animator _aim;
    //[HideInInspector]
    public bool _isExploding;
    private DarkMagic darkMagic;
    public Rigidbody2D Rb;
    public CircleCollider2D Collider;


    private void Awake() 
    {
        _aim = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        _aim.SetBool("aim", true);
        darkMagic = gameObject.GetComponentInParent<DarkMagic>();
        Rb.simulated = false;
    }

    private void Update() 
    {
    }

    public void DestroyEff()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(_isExploding && other.CompareTag("Player"))
        {
            PlayerDamageable playerDamageable = other.GetComponentInParent<PlayerDamageable>();
            playerDamageable.Damage(darkMagic._attackDetails);
        }
    }

    public void OnTriggerExit2D(Collider2D other) {
        
    }
  
}
