using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class Key : MonoBehaviour,IInteractable
{
   public void Interact()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
        inventory.PlayersInventory.Add(transform.gameObject);
        Debug.Log("added key to inventory");
        transform.gameObject.SetActive(false);
    }
}