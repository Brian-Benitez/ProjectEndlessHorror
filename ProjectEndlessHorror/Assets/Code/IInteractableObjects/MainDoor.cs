using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Will rename this to PuzzleChecker or something
public class MainDoor : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;

    public void Interact()
    {
        if (PlayerInventoryRef.DoesPlayerHaveKey())
            GameMain.instance.AdvanceToNextLevel();
        else
            Debug.Log("does not have the key");
    }
}
