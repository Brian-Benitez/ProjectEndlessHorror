using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;
using UnityEngine.ProBuilder.MeshOperations;

public class BathRoomRoateOtherWay : MonoBehaviour, IInteractable
{
    public bool DoorOpen = false;
    public void Interact()
    {
        if(!DoorOpen)
        {
            DoorOpen = true;
            transform.DORotate(new Vector3(0, -90, 0), 3f);
            AudioController.instance.PlayStallDoorOpenSound();
        }
        else
            return;
       
    }
}
