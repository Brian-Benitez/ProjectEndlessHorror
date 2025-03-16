using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour,IInteractable
{
    public PlayerInventory PlayerInventoryRef;
    public AudioController AudioControllerRef;
   public void Interact()
    {
        PlayerInventoryRef.PlayersInventoryList.Add(transform.gameObject);
        AudioControllerRef.PlayGrabKeysSound();
        Debug.Log("added key to inventory");
        transform.gameObject.SetActive(false);//set back to true later
    }
}
