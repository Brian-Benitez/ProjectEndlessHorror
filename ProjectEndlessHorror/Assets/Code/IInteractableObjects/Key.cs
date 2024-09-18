using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour,IInteractable
{
   public void Interact()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();
        inventory.PlayersInventoryList.Add(transform.gameObject);
        Debug.Log("added key to inventory");
        transform.gameObject.SetActive(false);
    }
}
