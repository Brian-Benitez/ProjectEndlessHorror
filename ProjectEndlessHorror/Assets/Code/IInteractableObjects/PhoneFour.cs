using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PhoneFour : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoomMechanic.TurnPhoneFourTrue();
        Debug.Log("phone 4 is clicked");
    }
}
