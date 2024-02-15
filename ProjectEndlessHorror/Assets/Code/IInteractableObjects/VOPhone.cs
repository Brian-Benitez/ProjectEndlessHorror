using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class VOPhone : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        puzzles.ClickedOnVOPhone = true;
    }
}
