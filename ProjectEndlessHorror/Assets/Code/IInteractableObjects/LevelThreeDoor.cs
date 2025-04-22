using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeDoor : MonoBehaviour, IInteractable
{
    public ReadPlayerInput ReadPlayerInputRef;
   public void Interact()
    {
        ReadPlayerInputRef.EnableLevelThreeInputText();
       
    }
}
