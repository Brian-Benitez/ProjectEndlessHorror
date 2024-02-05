using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class Door : MonoBehaviour, IInteractable
{
   public void Interact()
    {
        PlayerInteractions playerInteractions = FindObjectOfType<PlayerInteractions>();
        playerInteractions.LevelChecker();
    }
}
