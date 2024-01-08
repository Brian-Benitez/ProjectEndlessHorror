using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingRoomMechanic : MonoBehaviour
{
    public Transform StartSpawn;
    public GameObject RoomPrefab;
    public Transform RoomSpawnPos;
    public Transform Player;

    /// <summary>
    /// Throws the player back to the spawn point.
    /// </summary>
    public void SpawnBackToStart()
    {
        //Player.transform.position = StartSpawn.transform.position;
    }

    public void SpawnNewChunk()
    {
        Vector3 pos = RoomSpawnPos.transform.position;    
        Instantiate(RoomPrefab, pos, Quaternion.identity); 
    }

    //NOTE: here ill add all the puzzle checks. if pass, tell playerinteraction controller to let the player go to the next room
}
