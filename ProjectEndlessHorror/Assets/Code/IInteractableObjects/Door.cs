using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;
//Will rename this to PuzzleChecker or something
public class Door : MonoBehaviour, IInteractable
{
    public Puzzles Puzzle;
    public RoomRequirements requirements;
    public delegate void TestDelegate();

    public TestDelegate Test;   


    //Next up: Need to add another function to puzzles for checking if player has clicked on every phone 
    //Then subscribe to test.
    //(Im gonna change the names of the delegates but for now I wanna see if it works out in the end)
    //Maybe will add a interface to these puzzles to make it a bit diffrent every time but still be the same.
    private void Start()
    {
        //throws execption below idk why but it dont crash???????

        Test += Puzzle.KeyPuzzle;
        Test += requirements.CheckRoomRequirements;
    }

    public void Interact()
    {
        Test();
        /*
        LevelCheck levelCheck = FindObjectOfType<LevelCheck>();
        levelCheck.LevelChecker();
        */
    }
}
