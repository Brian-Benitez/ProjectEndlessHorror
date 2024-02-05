using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PhoneThree : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoomMechanic.TurnPhoneThreeTrue();
        Debug.Log("phone 3 is clicked");
    }
}
