using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Will rename this to PuzzleChecker or something
public class Door : MonoBehaviour, IInteractable
{
    public Puzzles Puzzle;
    public RoomRequirements requirements;
    public delegate void TestDelegate();

    public TestDelegate Test;

    private void Start()
    {
        Test += Puzzle.KeyPuzzleCheck;
        Test += requirements.CheckRoomRequirements;
    }

    public void Interact()
    {
        Test();
    }
}
