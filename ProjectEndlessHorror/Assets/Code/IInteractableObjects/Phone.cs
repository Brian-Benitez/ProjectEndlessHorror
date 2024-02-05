using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class Phone : MonoBehaviour, IInteractable
{
    public void Interact()
    {
       LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
       loopingRoomMechanic.TurnPhoneTrue();
       Debug.Log("phone is clicked");
    }
}
