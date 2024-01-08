using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingRoomMechanic : MonoBehaviour
{
    public Transform StartSpawn;
    public GameObject RoomPrefab;
    public Transform RoomSpawnPos;
    public Transform Player;

    public int CurrentLevel = 0;

    [Header("Player inventory")]
    public List<GameObject> PlayerInventory;

    [Header("Scripts")]
    public PlayerInteractions PI;

    /// <summary>
    /// This functions gives posistion on where the chunk should spawn in.
    /// Note:You will have to find a good pos for the room spawn pos to be in to be aline with other rooms
    /// </summary>
    public void SpawnNewChunk()
    {
        Vector3 pos = RoomSpawnPos.transform.position;    
        Instantiate(RoomPrefab, pos, Quaternion.identity); 
    }

    //NOTE: here ill add all the puzzle checks. if pass, tell playerinteraction controller to let the player go to the next room

    /// <summary>
    /// This function will check if the player has done everything they needed to do within the level, if they did they can move forward.
    /// </summary>
    public void LevelChecker()
    {
        switch (CurrentLevel)
        {
            case 0:
                Debug.Log("level check one");
                FirstPuzzle();
                break;
            case 1:
                Debug.Log("level two check");
                break;

            default:
                Debug.Log("default");
                break;
        }

        PI.AddNewChunk();
    }


    /// <summary>
    /// This puzzle requires you have a key to leave the room. When clicking on the door, it will check if you have a key in your inventory. If not, it wont open.
    /// </summary>
    public void FirstPuzzle()
    {
        foreach (GameObject item in PlayerInventory)
        {
            Debug.Log(item.gameObject.name);
            if(item.gameObject.name == "Key")
            {
                PI.CanOpenDoor = true;
                Debug.Log("door is open");
            }
            else
            {
                PI.CanOpenDoor = false;
                Debug.Log("player has not done everything in room");
            }
        }
    }
    /// <summary>
    /// Second puzzle requires tha player to do something idk
    /// </summary>
    public void SecondPuzzle()
    {

    }
}
