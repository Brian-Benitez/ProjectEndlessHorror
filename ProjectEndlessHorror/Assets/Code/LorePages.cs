using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LorePages : MonoBehaviour, IInteractable
{
    [Header("UI Of Page")]
    public GameObject PageLetterUI;

    [Header("Pages")]
    public List<GameObject> Pages;

    [Header("Booleans")]
    public bool PageIsOpen = false;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;
    public SettingsController SettingsControllerRef;

    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && PageIsOpen)
            DisableAllPages();
    }
    public void Interact()
    {
        PageIsOpen = true;
        SettingsControllerRef.PausePlayerMovement();
        Pages[LevelManagerRef.LevelIndex].SetActive(true); 
        PageLetterUI.SetActive(true);
    }

    public void DisableAllPages()
    {
        Pages.ForEach(p => p.SetActive(false));
        PageLetterUI.SetActive(false);
    }
}
