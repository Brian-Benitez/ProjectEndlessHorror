using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class Key : MonoBehaviour,IInteractable
{
   public void Interact()
    {
        LoopingRoomMechanic loopingRoom = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoom.PlayerInventory.Add(transform.gameObject);
        Debug.Log("added key to inventory");
        transform.gameObject.SetActive(false);
    }
}
