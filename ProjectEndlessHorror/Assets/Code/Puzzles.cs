using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzles : MonoBehaviour
{
    [Header("Scripts")]
    public PlayerInventory Inventory;
    public RoomRequirements RoomRequirement;
    public MonsterBehavior MonsterBehaviors;


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
    
    }
}
