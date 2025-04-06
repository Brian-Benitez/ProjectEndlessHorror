using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject PlayerPos;
    [Header("Nav Mesh Agent")]
    public NavMeshAgent MonsterNavMeshAgent;
    [Header("Booleans")]
    public bool IsOnMonsterNavMesh = false;
    [Header("Scripts")]
    public StartChaseSequnce StartChaseSequnceRef;

    private void Update()
    {
        if (StartChaseSequnceRef.IsChasingPlayer && !GameMain.instance.IsGameFinished)
            MonsterNavMeshAgent.SetDestination(PlayerPos.transform.position);

    }

    public void TurnOnMonstersNavMesh()
    {
        IsOnMonsterNavMesh = true;
        MonsterNavMeshAgent.enabled = true;
    }

    public void TurnOffMonstersNavMesh()
    {
        IsOnMonsterNavMesh = false;
        MonsterNavMeshAgent.enabled = false;    
    }
}
