using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class Door : MonoBehaviour, IInteractable
{
   public void Interact()
    {
        LevelCheck levelCheck = FindObjectOfType<LevelCheck>();
        levelCheck.LevelChecker();
    }
}
