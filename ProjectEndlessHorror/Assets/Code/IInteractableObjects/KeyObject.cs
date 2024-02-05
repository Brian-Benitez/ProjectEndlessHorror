using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static InteractableObject;

public class KeyObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoom = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoom.PlayerInventory.Add(transform.gameObject);
        transform.gameObject.SetActive(false);
        Debug.Log(transform.name + " was added to inventory");
    }
}
