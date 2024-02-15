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

    public void ClickPuzzleCheck()
    {
        //level two and three check here
        if(ClickedOnPhoneOne && ClickedOnPhoneTwo && ClickedOnPhoneThree && ClickedOnPhoneFour || ClickedPicFrameOne && ClickedPicFrameTwo)
        {
            if(ClickedOnVOPhone)
                /*
            Debug.Log("Play VO now");
            MonsterBehavior.MonsterPrefab.transform.position = MonsterBehavior.MonsterSpawnIn.transform.position;
            MonsterBehavior.MonsterPrefab.SetActive(true);
                */
            roomRequirements.CanOpenDoor = true;
        }
        else
            roomRequirements.CanOpenDoor = false;
       
    }
}
