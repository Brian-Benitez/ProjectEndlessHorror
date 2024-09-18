using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureTwo : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        //puzzles.ClickedPicFrameTwo   = true;
        Debug.Log("pic two is clicked");
    }
}
