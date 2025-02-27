using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EasterEggController : MonoBehaviour, IInteractable
{
    [Header("Booleans")]
    public bool IsEasterEggEnabled = false;

    public void Interact()
    {
        EasterEggCode();
    }

    private void EasterEggCode()
    {

    }

    private void EnableEasterEgg()
    {

    }
}
