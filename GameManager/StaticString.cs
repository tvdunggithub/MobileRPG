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
    public static int Attack = Animator.StringToHash("attack"); 
    public static int Spell = Animator.StringToHash("spell"); 
}
