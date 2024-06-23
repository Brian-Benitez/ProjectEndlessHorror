using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Player;
    public Transform PlayerSpawnPoint;

    [Header("GameObjects")]
    public GameObject RedExitSignObject;
    public GameObject GreenExitSignObject;
    public GameObject ExitDoorObject;
    public List<GameObject> RoomChunks;

    [Header("Ints")]
    public int RoomIndex;
    //NEW IDEA ALERT: Have it so it spawns the whole chunk and make prefabs.
    //For transitions, fade to black then spawn to new area.
   
    /// <summary>
    /// Spawns A new chunk of the level at the end of the level
    /// </summary>
    public void SpawnNewRoomChunk()
    {
        RoomChunks[RoomIndex].SetActive(false);
        RepositionPlayer();
        /*
        RoomIndex++;
        Instantiate(RoomChunks[RoomIndex], ChunkSpawnPoint);
        */
        //Commenting this out until I get here.//The plan is i put all the rooms in a list then just go up by one when calling this function.
        //RoomChunks[RoomIndex].SetActive(true);
    }
    /// <summary>
    /// Spawns the player back into pos after finishing a level. TODO: Will need to add fade in and out.
    /// </summary>
    public void RepositionPlayer()
    {
        Player.transform.position = PlayerSpawnPoint.transform.position;
        Debug.Log("hhhh");
    }

    public void RestartLevelManager()
    {
        RoomIndex = 0;
    }
}
