using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMonsterMovement : MonoBehaviour
{
    public MonsterBehavior MonsterBehaviorRef;
 
    private void OnTriggerEnter(Collider colliderTrigger)
    {
        if (colliderTrigger.CompareTag("Player"))
        {
            StartCoroutine(MonsterBehaviorRef.MoveMonsterToPoint());
            Debug.Log("this plays");
        }
           
    }
}
