using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneFour : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        puzzles.ClickedOnPhoneFour = true;
        Debug.Log("phone 4 is clicked");
    }
}
