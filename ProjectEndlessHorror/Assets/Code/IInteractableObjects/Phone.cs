using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInteractable
{
    public void Interact()
    {
       Puzzles puzzles = GetComponent<Puzzles>();
       puzzles.ClickedOnPhoneOne = true;
       Debug.Log("phone is clicked");
    }
}
