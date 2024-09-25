using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideDoor : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;
    public void Interact()
    {
        if (PlayerInventoryRef.DoesPlayerHaveSecondDoorKey())
            LevelManagerRef.RotateSideDoor();
        else
            Debug.Log("player does not have a second door key");
    }
}
