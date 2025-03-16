using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;
using DG.Tweening;

public class BathRoomDoor : MonoBehaviour, IInteractable
{
    public AudioController AudioControllerRef;
    public void Interact()
    {
        transform.DORotate(new Vector3(0, 100, 0), 3f);
        AudioControllerRef.PlayStallDoorOpenSound();
    }
}
