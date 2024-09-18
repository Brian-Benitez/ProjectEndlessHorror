using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Player;
    public Transform PlayerSpawnPoint;

    [Header("Ints")]
    public int RoomIndex;
    //NEW IDEA ALERT: Have it so it spawns the whole chunk and make prefabs.
    //For transitions, fade to black then spawn to new area.

    public GameMain GameMainRef;

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
