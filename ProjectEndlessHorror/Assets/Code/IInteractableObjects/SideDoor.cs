using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoor : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        RoomRequirements roomRequirements = FindObjectOfType<RoomRequirements>();
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        puzzles.KeyPuzzleCheck();
        //roomRequirements.CheckSecondDoorRequirements();
    }
}
