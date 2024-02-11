using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerInventory inventory;
    public RoomRequirements roomRequirements;

    //This checks for collecting things in a room
    public void KeyPuzzle()
    {
        Debug.Log("conditions check...");
        foreach (GameObject item in inventory.PlayersInventory)
        {
            Debug.Log(item.gameObject.name);
            if (item.gameObject.name == "Key")
            {
                roomRequirements.CanOpenDoor = true;
                Debug.Log("door can be open");
            }
            else
            {
                roomRequirements.CanOpenDoor = false;
                Debug.Log("player has not done have the key to leave the room");
            }
        }
    }
}
