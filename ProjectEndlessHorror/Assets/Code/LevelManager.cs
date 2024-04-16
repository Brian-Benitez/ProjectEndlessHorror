using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject RoomGameObject;
    public GameObject RedExitSignObject;
    public GameObject GreenExitSignObject;
    public GameObject ExitDoorObject;
    public GameObject MainStairs;
    public GameObject HallWay;

    [Header("Spawn Positions")]
    public GameObject StairsSpawnPosition;
    public GameObject HallWaySpawnPostion;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewChunk();
            Debug.Log("i am clickjed");
        }
    }
    /// <summary>
    /// Spawns A new chunk of the level at the end of the level
    /// </summary>
    public void SpawnNewChunk()
    {
        MainStairs.gameObject.transform.position = StairsSpawnPosition.gameObject.transform.position;
        HallWay.gameObject.transform.position = HallWaySpawnPostion.gameObject.transform.position;
    }

    public void SpawnPuzzleChunks()
    {

    }
}
