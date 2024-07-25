using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneThree : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = GetComponent<Puzzles>();
        puzzles.ClickedOnPhoneThree = true;
        Debug.Log("phone 3 is clicked");
    }
}
