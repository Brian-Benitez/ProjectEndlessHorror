using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PhoneThree : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        puzzles.ClickedOnPhoneThree = true;
        Debug.Log("phone 3 is clicked");
    }
}
