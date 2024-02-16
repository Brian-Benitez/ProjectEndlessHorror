using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerInventory inventory;
    public RoomRequirements roomRequirements;


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


    //This checks for collecting things in a room
    public void KeyPuzzleCheck()
    {
        Debug.Log("conditions check...");
        foreach (GameObject item in inventory.PlayersInventory)
        {
            Debug.Log(item.gameObject.name);
            //Level one check here
            if (item.gameObject.name == "Key" || item.gameObject.name == "KeyObject" || item.gameObject.name == "Key Two")
            {
                roomRequirements.CanOpenDoor = true;
                Debug.Log("door can be open");
            }
            else
            {
                Debug.Log("player has not done have the key to leave the room");
            }
        }
        //need to tell all these booleans to stfu
        if (ClickedOnPhoneOne && ClickedOnPhoneTwo && ClickedOnPhoneThree && ClickedOnPhoneFour)
        {
            roomRequirements.CanOpenDoor = true;
            if (ClickedOnVOPhone)
                Debug.Log("fucckkck");
                /*
            Debug.Log("Play VO now");
            MonsterBehavior.MonsterPrefab.transform.position = MonsterBehavior.MonsterSpawnIn.transform.position;
            MonsterBehavior.MonsterPrefab.SetActive(true);
                */
               
        }
        else if(ClickedPicFrameOne && ClickedPicFrameTwo)
        {
            roomRequirements.CanOpenDoor = true;
            Debug.Log("hshsshshhshhs");
        }
            
    }
}
