using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PictureOne : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoomMechanic.TurnPicOneFrameTrue();
        Debug.Log("pic one is clicked");
    }
}
