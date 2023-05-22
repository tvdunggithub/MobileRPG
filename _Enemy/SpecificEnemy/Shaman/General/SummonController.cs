using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonController : MonoBehaviour
{
   public GameObject EnemyPrefeb;

   private void AnimationFinished()
   {
        Instantiate(EnemyPrefeb, transform.position, Quaternion.identity);
        Destroy(gameObject);
   }
}
