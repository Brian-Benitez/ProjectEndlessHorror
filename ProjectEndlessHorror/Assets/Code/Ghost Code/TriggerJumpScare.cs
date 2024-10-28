using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerJumpScare : MonoBehaviour
{
    public MonsterBehavior MonsterBehaviorRef;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            MonsterBehaviorRef.MonstersJumpScarePosition();
    }
}
