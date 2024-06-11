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
    public Transform StairsSpawnPosition;
    public Transform HallWaySpawnPostion;

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
        GameObject clone = Instantiate(MainStairs, StairsSpawnPosition);
        GameObject hallWayClone = Instantiate(HallWay, HallWaySpawnPostion);
        Debug.Log("ahahahha");
       //THIS IS ALL FUCKED, NEED TO WORK AND SEE WHY MY SPAWNS ARE SO FAR AWAY.
    }
}
