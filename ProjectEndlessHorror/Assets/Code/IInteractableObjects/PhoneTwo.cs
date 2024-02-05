using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PhoneTwo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoomMechanic.TurnPhoneTwoTrue();
        Debug.Log("phone 2 is clicked");
    }
}
