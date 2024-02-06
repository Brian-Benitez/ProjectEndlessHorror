using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelChunk : MonoBehaviour
{
    public GameObject RoomPrefab;
    public Transform RoomSpawnPos;
    /// <summary>
    /// This functions gives posistion on where the chunk should spawn in.
    /// Note:You will have to find a good pos for the room spawn pos to be in to be aline with other rooms
    /// </summary>
    public void SpawnNewChunk()
    {
        Vector3 pos = RoomSpawnPos.transform.position;
        Instantiate(RoomPrefab, pos, Quaternion.identity);
    }
}
