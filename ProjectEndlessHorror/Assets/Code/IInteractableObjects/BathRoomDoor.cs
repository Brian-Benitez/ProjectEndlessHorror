using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;
using DG.Tweening;

public class BathRoomDoor : MonoBehaviour, IInteractable
{
    public bool DoorOpen = false;
    public void Interact()
    {
        if (!DoorOpen)
        {
            transform.DORotate(new Vector3(0, 100, 0), 3f);
            AudioController.instance.PlayStallDoorOpenSound();
            DoorOpen = true;
        }
        else
            return;
    }
}
