using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class PictureTwo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        puzzles.ClickedOnPhoneTwo = true;
        Debug.Log("pic two is clicked");
    }
}
