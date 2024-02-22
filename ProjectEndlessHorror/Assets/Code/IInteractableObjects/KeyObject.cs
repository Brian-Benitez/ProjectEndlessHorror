using interfaces;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class KeyObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
        inventory.PlayersInventory.Add(transform.gameObject);
        transform.gameObject.SetActive(false);
        Debug.Log(transform.name + " was added to inventory");
    }
}
