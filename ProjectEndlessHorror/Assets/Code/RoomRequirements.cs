using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRequirements : MonoBehaviour
{
    [Header("Scripts")]
    public SpawnLevelChunk spawnLevelChunk;
    public LevelCheck levelCheck;

    [Header("Booleans")]
    [SerializeField]
    public bool CanOpenDoor = false;
    [SerializeField]
    public bool CanOpenSecondDoor = false;

    //dont need this but will use it below
    [Header("GameObjects")]
    public GameObject Door;
    public GameObject SecondDoor;

    /// <summary>
    /// Checks if the bool is true, if it is, spawn new chunk into map.
    /// NOTE: need to put can open door to false somewhere else.
    /// </summary>
    /// BE IN OWN SCRPIT
    public void CheckRoomRequirements()
    {
        if (CanOpenDoor == true)
        {
            Door.transform.position = new Vector3(0, 90, 0);
            spawnLevelChunk.SpawnNewChunk();
            levelCheck.CurrentLevel++;
            Debug.Log("new current level is " + levelCheck.CurrentLevel);
        }
        else
        {
            Debug.Log("Does not have everything to move forward");
        }
    }
    //BE IN OWN SCPRIPT
    public void CheckSecondDoorRequirements()
    {
        if (CanOpenSecondDoor == true)
        {
            SecondDoor.transform.position = new Vector3(0, 90, 0);
            //add new transform to door here.
        }
        else
            Debug.Log("Door needs key");
    }
}
