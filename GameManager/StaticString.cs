using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticString 
{
    public static string Player = "Player";
    public static string Immune = "Immune";
    public static string Alive = "Alive";
    public static int Dash = Animator.StringToHash("dash"); 
    public static int Idle = Animator.StringToHash("idle"); 
    public static int Dead = Animator.StringToHash("dead"); 
    public static int Move = Animator.StringToHash("move"); 
    public static int Walk = Animator.StringToHash("walk"); 
    public static int Run = Animator.StringToHash("run"); 
    public static int Attack = Animator.StringToHash("attack"); 
    public static int MeleeAttack = Animator.StringToHash("meleeAttack"); 
    public static int RangedAttack = Animator.StringToHash("rangedAttack"); 
    public static int Spell = Animator.StringToHash("spell"); 
    public static int PlayerDetected = Animator.StringToHash("playerDetected");
    public static int Throwing = Animator.StringToHash("throwing");  
    public static int Protect = Animator.StringToHash("protect");
    public static int MagicOne = Animator.StringToHash("magic1"); 
    public static int MagicTwo = Animator.StringToHash("magic2"); 
    public static int MagicThree = Animator.StringToHash("magic3"); 
    public static int Chasing = Animator.StringToHash("chasing"); 
    public static int Explosion = Animator.StringToHash("explosion"); 

    
}
