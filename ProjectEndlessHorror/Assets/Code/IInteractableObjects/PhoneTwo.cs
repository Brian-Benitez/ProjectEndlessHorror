using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTwo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = GetComponent<Puzzles>();
        puzzles.ClickedOnPhoneTwo = true;
        Debug.Log("phone 2 is clicked");
    }
}
