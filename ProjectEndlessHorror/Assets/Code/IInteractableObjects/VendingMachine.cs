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

    public void Interact()
    {
        if(PlayerInventoryRef.DoesPlayerHaveADollar())
        {
            MainKey.gameObject.SetActive(true);
        }
    }
}
