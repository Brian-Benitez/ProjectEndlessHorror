using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LoopingRoomMechanic : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerInteractions PI;
    public RoomRequirements RoomRequirements;
    public MonsterBehavior MonsterBehavior;
    public PlayerInventory PlayerInventory;
    //need this above

    /// <summary>
    /// This puzzle requires you have a key to leave the room. When clicking on the door, it will check if you have a key in your inventory. If not, it wont open.
    /// </summary>
    public void FirstPuzzle()
    {
        foreach (GameObject item in PlayerInventory.PlayersInventory)
        {
            Debug.Log(item.gameObject.name);
            if(item.gameObject.name == "Key")
            {
                RoomRequirements.CanOpenDoor = true;
                Debug.Log("door is open");
            }
            else
            {
                //RoomRequirements.CanOpenDoor = false;
                Debug.Log("player has not done everything in room");
            }
        }
    }
   
    /// <summary>
    /// Player finds key to then open a door in the office to then pick up a item to open the door to another room.
    /// </summary>
    public void FourthPuzzle()
    {
        foreach (GameObject item in PlayerInventory.PlayersInventory)
        {
            Debug.Log(item.gameObject.name);
            if(item.gameObject.name == "KeyObject")
            {
                RoomRequirements.CanOpenDoor = true;
            }
            else
            {
                Debug.Log("keyobject was not found.");
            }
        }
    }

    public void FourthPuzzlePtTwo()
    {
        foreach(GameObject item in PlayerInventory.PlayersInventory)
        {
            if (item.gameObject.name == "Key Two")
            {
                RoomRequirements.CanOpenSecondDoor = true;
            }
            else
            {
                Debug.Log("key 2 was not found in inventory");
            }
        }
    }
}
