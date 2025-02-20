using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorePages : MonoBehaviour, IInteractable
{
    [Header("Pages")]
    public List<GameObject> Pages;

    [Header("Booleans")]
    public bool PageIsOpen = false;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;

    public void Update()
    {
        
    }
    public void Interact()
    {
        PageIsOpen = true;
        Pages[LevelManagerRef.LevelIndex].SetActive(true); 
    }

    public void DisableAllPages() => Pages.ForEach(p => p.SetActive(false));
}
