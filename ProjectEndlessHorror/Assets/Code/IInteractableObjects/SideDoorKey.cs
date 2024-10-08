using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;

public class SideDoorKey : MonoBehaviour, IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public void Interact()
    {
        PlayerInventoryRef.PlayersInventoryList.Add(transform.gameObject);
        Debug.Log("added Side key to inventory");
        transform.gameObject.SetActive(false);
    }
}
