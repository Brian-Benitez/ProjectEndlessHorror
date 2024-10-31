using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorKeyPad : MonoBehaviour, IInteractable
{
    public ReadPlayerInput ReadPlayerInputRef;
    public void Interact()
    {
        ReadPlayerInputRef.EnablePlayersInputText();
    }
}
