using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PlayerInteractions : MonoBehaviour
{
    [Header("Scripts")]
    public LoopingRoomMechanic LRM;

    //dont need this but will use it below
    [Header("GameObjects")]
    public GameObject Door;
    public GameObject SecondDoor;

    [Header("Booleans")]
    [SerializeField]
    public bool CanOpenDoor = false;
    [SerializeField]
    public bool CanOpenSecondDoor = false;
   //How this works,
   //The player shoots a raycast on the door.
   //Then in looping room mechanic, it will check to see if everything is done in the room.
   //If it is, spawn new room, then player goes through.

    //do polymofism for below
    //Then check if it has interact
    void Update()
    {
        //player input
        Ray ray = new Ray(transform.position, transform.forward);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Interact();
                }
                #region old code
                /*
                Debug.Log(hit.transform.name);
                switch (hit.transform.name)
                {
                    case "Door":
                        LevelChecker();
                        break;
                    case "Phone":
                        LRM.TurnPhoneTrue();
                        Debug.Log("phone is clicked");
                        break;
                    case "Phone 2":
                        LRM.TurnPhoneTwoTrue();
                        Debug.Log("phone 2 is clicked");
                        break;
                    case "Phone 3":
                        LRM.TurnPhoneThreeTrue();
                        Debug.Log("phone 3 is clicked");
                        break;
                    case "Phone 4":
                        LRM.TurnPhoneFourTrue();
                        Debug.Log("phone 4 is clicked");
                        break;
                    case "PictureOne":
                        LRM.TurnPicOneFrameTrue();
                        Debug.Log("pic one is clicked");
                        break;
                    case "PictureTwo":
                        LRM.TurnPicTwoFrameTrue();
                        Debug.Log("pic two is clicked");
                        break;
                    case "Key Two":
                        LRM.PlayerInventory.Add(hit.transform.gameObject);
                        hit.transform.gameObject.SetActive(false);
                        Debug.Log("add " + hit.transform.name + " to inventory.");
                        break;
                    case "SideDoor":
                        LRM.FourthPuzzlePtTwo();
                        CheckSecondDoorRequirements();
                        Debug.Log("seeing if all requirements are met.");
                        break;
                    case "KeyObject":
                        LRM.PlayerInventory.Add(hit.transform.gameObject);
                        hit.transform.gameObject.SetActive(false);
                        Debug.Log(hit.transform.name + " was added to inventory");
                        break;
                    case "VO Phone":
                        Debug.Log("Phone has been activated");
                        LRM.ActivatedVOPhone();
                        LRM.FifthPuzzle();
                        break;

                    default:
                        break;
                }
                */
                #endregion old code
            }
        }
    }

    /// <summary>
    /// This function will check if the player has done everything they needed to do within the level, if they did they can move forward.
    /// </summary>
    /// //BE IN OWN SCRPIT
    public void LevelChecker()
    {
        switch (LRM.CurrentLevel)
        {
            case 0:
                Debug.Log("level check one");
                LRM.FirstPuzzle();
                break;
            case 1:
                Debug.Log("level two check");
                LRM.SecondPuzzle();
                break;
            case 2:
                Debug.Log("level three check");
                LRM.ThirdPuzzle();
                break;
            case 3:
                Debug.Log("level four check");
                LRM.FourthPuzzle();
                break;

            default:
                Debug.Log("default");
                break;
        }

        CheckRoomRequirements();
    }

    /// <summary>
    /// Checks if the bool is true, if it is, spawn new chunk into map.
    /// NOTE: need to put can open door to false somewhere else.
    /// </summary>
    /// BE IN OWN SCRPIT
    public void CheckRoomRequirements()
    {
        if (CanOpenDoor == true)
        {
            Door.transform.position = new Vector3(0, 90, 0);
            LRM.SpawnNewChunk();
            LRM.CurrentLevel++;
            Debug.Log("new current level is " + LRM.CurrentLevel);
        }
        else
        {
            Debug.Log("Does not have everything to move forward");
        }
    }
    //BE IN OWN SCPRIPT
    public void CheckSecondDoorRequirements()
    {
        if (CanOpenSecondDoor == true)
        {
            SecondDoor.transform.position = new Vector3(0, 90, 0);
            //add new transform to door here.
        }
        else
            Debug.Log("Door needs key");
    }
}
