using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class SideDoor : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoom = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoom.FourthPuzzlePtTwo();
        PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
        playerInteractions.CheckSecondDoorRequirements();
    }
}
