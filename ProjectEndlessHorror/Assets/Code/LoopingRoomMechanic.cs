using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class LoopingRoomMechanic : MonoBehaviour
{
    public Transform StartSpawn;
    public GameObject RoomPrefab;
    public Transform RoomSpawnPos;
    public Transform Player;

    [Header("Level counter")]
    public int CurrentLevel = 0;

    [Header("Player inventory")]
    public List<GameObject> PlayerInventory;

    [Header("Scripts")]
    public PlayerInteractions PI;

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
                SecondPuzzle();
                break;
            case 2:
                Debug.Log("level three check");
                ThirdPuzzle();
                break;

            default:
                Debug.Log("default");
                break;
        }

        PI.CheckRoomRequirements();
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
    /// Second puzzle requires tha player to click on 4 phones in the room to move forward.
    /// </summary>
    public void SecondPuzzle()
    {
        if(ClickedOnPhoneOne && ClickedOnPhoneTwo && ClickedOnPhoneThree && ClickedOnPhoneFour == true)
        {
            PI.CanOpenDoor = true;
        }
        else
        {
            PI.CanOpenDoor = false;
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
            PI.CanOpenDoor = true;
        }
        else
        {
            PI.CanOpenDoor = false;
            Debug.Log("all picture frames have not been clicked");
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
    //Same thing here :( ^
}