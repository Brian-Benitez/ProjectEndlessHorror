using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomRequirements : MonoBehaviour
{
    
    [Header("Booleans")]
    [SerializeField]
    public bool MoveToNewRoom = false;
    [SerializeField]
    public bool CanOpenSecondDoor = false;

    //dont need this but will use it below
    //[Header("GameObjects")]
   // public GameObject Door;//
    //public GameObject SecondDoor;

    [Header("Scripts")]
    public Puzzles Puzzle;
    public PlayerInventory playerInventory;


    /// <summary>
    /// Checks if the bool is true, if it is, spawn new chunk into map.
    /// NOTE: need to put can open door to false somewhere else.
    /// </summary>
    public void CheckRoomRequirements()
    {
        if (MoveToNewRoom == true)
        {
            //check this below its not right nor is it in the right place.
            //Door.transform.position = new Vector3(0, 90, 0);
            Debug.Log("door is open");
            //playerInventory.PlayersInventory.Clear();
            //RestartDoorRequirements();
        }
        else
        {
            Debug.Log("Does not have everything to move forward");
        }
    }
    /*
    public void CheckSecondDoorRequirements()
    {
        if (CanOpenSecondDoor == true)
        {
            //SecondDoor.transform.position = new Vector3(0, 90, 0);
            //SecondDoor.SetActive(false);
            //add new transform to door here.
        }
        else
            Debug.Log("Door needs key");
    }
    */
    public void RestartDoorRequirements()
    {
        MoveToNewRoom = false;
        Puzzle.ClickedOnPhoneOne = false;
        Puzzle.ClickedOnPhoneTwo = false;
        Puzzle.ClickedOnPhoneThree = false;
        Puzzle.ClickedOnPhoneFour = false;
        Debug.Log("restart everything");
        //maybe add more here
    }
}
