using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour
{
    public LoopingRoomMechanic LoopingRoomMechanic;
    public RoomRequirements RoomRequirements;


    [Header("Level counter")]
    public int CurrentLevel = 0;

    ///THIS ALL NEEDS TO BE DELETED AND NOT USED ANYMORE. GONNA USE DELEGATES TO SORT THIS BETTER
    /// <summary>
    /// This function will check if the player has done everything they needed to do within the level, if they did they can move forward.
    /// </summary>
    public void LevelChecker()
    {
        switch (CurrentLevel)
        {
            case 0:
                //Debug.Log("level check one");
                //LoopingRoomMechanic.FirstPuzzle();
                break;
            case 1:
                //Debug.Log("level two check");
                //LoopingRoomMechanic.SecondPuzzle();
                break;
            case 2:
                //Debug.Log("level three check");
                //LoopingRoomMechanic.ThirdPuzzle();
                break;
            case 3:
                Debug.Log("level four check");
                LoopingRoomMechanic.FourthPuzzle();
                break;

            default:
                Debug.Log("default");
                break;
        }

        RoomRequirements.CheckRoomRequirements();
    }
}
