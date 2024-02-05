using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class KeyTwo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoomMechanic.PlayerInventory.Add(transform.gameObject);
        Debug.Log("added key 2 to inventory");
        transform.gameObject.SetActive(false);
    }
}
