using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InteractableObject;

public class Phone : MonoBehaviour, IInteractable
{
    public void Interact()
    {
       Puzzles puzzles = FindObjectOfType<Puzzles>();
       puzzles.ClickedOnPhoneOne = true;
       Debug.Log("phone is clicked");
    }
}
