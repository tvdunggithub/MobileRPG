using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpController : MonoBehaviour
{
    private float _xScaleOnStart;
    public Transform Transform;

    private void Awake() 
    {
        Transform = transform;
        _xScaleOnStart = Transform.localScale.x;       
    }

    public void ReduceHp(float percentage)
    {
        Vector3 temp = new Vector3(_xScaleOnStart * percentage, Transform.localScale.y, Transform.localScale.z);
        Transform.localScale = temp;
    }
}
