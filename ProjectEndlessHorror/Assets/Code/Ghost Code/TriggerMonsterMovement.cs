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
            MonsterBehaviorRef.StartMonsterMovement();
            Debug.Log("this plays");
        }
        this.gameObject.SetActive(false);
    }
}
