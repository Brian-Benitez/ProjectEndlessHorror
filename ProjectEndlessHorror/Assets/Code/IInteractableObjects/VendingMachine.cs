using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class VendingMachine : MonoBehaviour, IInteractable
{
    [Header("Game Objects")]
    public GameObject MainKey;
    public GameObject VendingMachineKey;                                     

    [Header("Scripts")]
    public PlayerInventory PlayerInventoryRef;
    public LevelManager LevelManagerRef;

    public void Interact()
    {
        if (PlayerInventoryRef.DoesPlayerHaveADollar() && LevelManagerRef.LevelIndex == 4)
        {
            MainKey.gameObject.SetActive(true);
            AudioController.instance.PlayKeyFallingOnFloorSound();
            VendingMachineKey.gameObject.SetActive(false);   
            Debug.Log("key is gone!");
        }
    }
}
