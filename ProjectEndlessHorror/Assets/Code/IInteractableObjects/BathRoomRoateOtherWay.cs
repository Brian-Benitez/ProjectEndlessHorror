using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using interfaces;

public class BathRoomRoateOtherWay : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        transform.DORotate(new Vector3(0, -90, 0), 3f);
        Debug.Log("ROATATE BITCH");
    }
}
