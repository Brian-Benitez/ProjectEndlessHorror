using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChaseSequnce : MonoBehaviour
{
    [Header("Booleans")]
    public bool IsChasingPlayer = false;
    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;
    public MonsterMovement MonsterMovementRef;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsChasingPlayer = true;
            MonsterBehaviorRef.EnableObject();
            MonsterBehaviorRef.SpawnMonsterInArea();
            MonsterMovementRef.TurnOnMonstersNavMesh();
            AudioController.instance.SwapToScaryChaseTrack();
        }
    }

    public void TurnOffChaseBool() => IsChasingPlayer = false;
}
