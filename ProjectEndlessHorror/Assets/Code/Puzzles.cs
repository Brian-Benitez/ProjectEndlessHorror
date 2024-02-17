using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerInventory inventory;
    public RoomRequirements roomRequirements;
    public MonsterBehavior monsterBehavior;


    [Header("Level two objects")]

    public bool ClickedOnPhoneOne = false;

    public bool ClickedOnPhoneTwo = false;

    public bool ClickedOnPhoneThree = false;

    public bool ClickedOnPhoneFour = false;

    [Header("Level Three Objects")]

    public bool ClickedPicFrameOne = false;

    public bool ClickedPicFrameTwo = false;



    [Header("Level five Object")]
    public bool ClickedOnVOPhone = false;


    //This checks for collecting things and clicking on things in a room
    public void KeyPuzzleCheck()
    {
        Debug.Log("conditions check...");
        foreach (GameObject item in inventory.PlayersInventory)
        {
            Debug.Log(item.gameObject.name);
            //Checks for key puzzles in the room
            if (item.gameObject.name == "Key")
            {
                //This checks if a key is picked up
                roomRequirements.CanOpenDoor = true;
                Debug.Log("door can be open");
            }
            else if (item.gameObject.name == "SideDoorKey")
            {
                //This check is for a second door to open later in a level
                Debug.Log("second door can be open");
                roomRequirements.CanOpenSecondDoor = true;
            }
            else
            {
                Debug.Log("player has not done have the key to leave the room");
            }
        }
        if (ClickedOnPhoneOne && ClickedOnPhoneTwo && ClickedOnPhoneThree && ClickedOnPhoneFour)
        {
            roomRequirements.CanOpenDoor = true;  
        }
        else if(ClickedPicFrameOne && ClickedPicFrameTwo)
        {
            roomRequirements.CanOpenDoor = true;
            Debug.Log("hshsshshhshhs");
        }
        else if (ClickedOnVOPhone)
        {
            roomRequirements.CanOpenDoor = true;
        }


    }
}
