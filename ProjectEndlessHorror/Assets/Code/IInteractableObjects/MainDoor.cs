using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainDoor : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;

    public void Interact()
    {
        if(LevelManagerRef.LevelIndex == 0)
            LevelManagerRef.RepositionPlayer();

        if (PlayerInventoryRef.DoesPlayerHaveKey())
            GameMain.instance.AdvanceToNextLevel();
        else
            Debug.Log("does not have the key");
    }
}
