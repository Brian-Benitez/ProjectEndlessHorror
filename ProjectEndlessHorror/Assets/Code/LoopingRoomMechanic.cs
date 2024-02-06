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

    [Header("Level two objects")]
    [SerializeField]
    private bool ClickedOnPhoneOne = false;
    [SerializeField]
    private bool ClickedOnPhoneTwo = false;
    [SerializeField]
    private bool ClickedOnPhoneThree = false;
    [SerializeField]
    private bool ClickedOnPhoneFour = false;

    [Header("Level Three Objects")]
    [SerializeField]
    private bool ClickedPicFrameOne = false;
    [SerializeField]
    private bool ClickedPicFrameTwo = false;

    [Header("Level five Object")]
    private bool ClickedOnVOPhone = false;

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
                RoomRequirements.CanOpenDoor = false;
                Debug.Log("player has not done everything in room");
            }
        }
    }
    /// <summary>
    /// Second puzzle requires tha player to click on 4 phones in the room to move forward.
    /// </summary>
    public void SecondPuzzle()
    {
        if(ClickedOnPhoneOne && ClickedOnPhoneTwo && ClickedOnPhoneThree && ClickedOnPhoneFour == true)
        {
            RoomRequirements.CanOpenDoor = true;
        }
        else
        {
            RoomRequirements.CanOpenDoor = false;
            Debug.Log("all phones have not been clicked.");
        }
    }
    /// <summary>
    /// Third puzzle is like the second one, click on 2 things to move forward.
    /// </summary>
    public void ThirdPuzzle()
    {
        if(ClickedPicFrameOne && ClickedPicFrameTwo == true)
        {
            RoomRequirements.CanOpenDoor = true;
        }
        else
        {
            RoomRequirements.CanOpenDoor = false;
            Debug.Log("all picture frames have not been clicked");
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
    //This puzzle is solved if you did or did not listen to the VA
    //Need more stuff though

    public void FifthPuzzle()
    {
        if(ClickedOnVOPhone)
        {
            Debug.Log("Play VO now");
           MonsterBehavior.MonsterPrefab.transform.position = MonsterBehavior.MonsterSpawnIn.transform.position;

           MonsterBehavior.MonsterPrefab.SetActive(true);

            RoomRequirements.CanOpenDoor = true;
        }
    }
    //Trying to pratice good code practice but idk if this is good?:(
    public void TurnPhoneTrue()
    {
        ClickedOnPhoneOne = true;
    }
    public void TurnPhoneTwoTrue()
    {
        ClickedOnPhoneTwo = true;
    }
    public void TurnPhoneThreeTrue()
    {
        ClickedOnPhoneThree = true;
    }
    public void TurnPhoneFourTrue()
    {
        ClickedOnPhoneFour = true;
    }
    public void TurnPicOneFrameTrue()
    {
        ClickedPicFrameOne = true;
    }
    public void TurnPicTwoFrameTrue()
    {
        ClickedPicFrameTwo = true;
    }

    public void ActivatedVOPhone()
    {
        ClickedOnVOPhone = true;
    }
    //Same thing here :( ^
}
