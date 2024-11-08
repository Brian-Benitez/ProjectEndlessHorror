using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour, IInteractable
{
    [Header("Game Objects")]
    public GameObject MainKey;

    [Header("Scripts")]
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;

    public void Interact()
    {
        if (PlayerInventoryRef.DoesPlayerHaveADollar() && LevelManagerRef.LevelIndex == 4)
        {
            MainKey.gameObject.SetActive(true);
        }
    }
}
