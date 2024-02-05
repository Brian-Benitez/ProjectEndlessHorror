using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PictureTwo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        LoopingRoomMechanic loopingRoomMechanic = FindObjectOfType<LoopingRoomMechanic>();
        loopingRoomMechanic.TurnPicTwoFrameTrue();
        Debug.Log("pic two is clicked");
    }
}
