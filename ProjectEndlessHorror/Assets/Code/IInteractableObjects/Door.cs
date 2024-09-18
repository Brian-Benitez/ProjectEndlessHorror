using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Will rename this to PuzzleChecker or something
public class Door : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public GameMain GameMainRef;

    public void Interact()
    {
        if (PlayerInventoryRef.DoesPlayerHaveKey())
            GameMainRef.AdvanceToNextLevel();
        else
            Debug.Log("does not have the key");
    }
}
