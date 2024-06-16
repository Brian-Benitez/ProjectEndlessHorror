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
    public Transform ChunkSpawnPoint;
    //NEW IDEA ALERT: Have it so it spawns the whole chunk and make prefabs.
    //For transitions, fade to black then spawn to new area.
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNewChunk();
            Debug.Log("i am clicked");
        }
    }
    /// <summary>
    /// Spawns A new chunk of the level at the end of the level
    /// </summary>
    public void SpawnNewChunk()
    {
        
    }
}
