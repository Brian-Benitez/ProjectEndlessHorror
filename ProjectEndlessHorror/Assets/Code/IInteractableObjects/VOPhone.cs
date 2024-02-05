using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class VOPhone : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoom = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoom.ActivatedVOPhone();
        loopingRoom.FifthPuzzle();
    }
}
