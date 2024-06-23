using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Will rename this to PuzzleChecker or something
public class Door : MonoBehaviour, IInteractable
{
    public Puzzles Puzzle;
    public RoomRequirements Requirements;

    public void Interact()
    {
        Requirements.CheckRoomRequirements();
    }
}
