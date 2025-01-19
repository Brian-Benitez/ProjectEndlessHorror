using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChaseSequnce : MonoBehaviour
{
    public MonsterBehavior MonsterBehaviorRef;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            MonsterBehaviorRef.ChasePlayer();
            
    }
}
