using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingRoomMechanic : MonoBehaviour
{
    public Transform StartSpawn;

    public Transform Player;

    /// <summary>
    /// Throws the player back to the spawn point.
    /// </summary>
    public void SpawnBackToStart()
    {
        Player.transform.position = StartSpawn.transform.position;
    }

    //NOTE: here ill add all the puzzle checks. if pass, tell playerinteraction controller to let the player go to the next room
}
