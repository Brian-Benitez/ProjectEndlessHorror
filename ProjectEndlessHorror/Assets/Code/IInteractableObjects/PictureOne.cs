using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureOne : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Puzzles puzzles = FindObjectOfType<Puzzles>();
        //puzzles.ClickedPicFrameOne = true;
        //Debug.Log("pic one is clicked and is " + puzzles.ClickedPicFrameOne);
    }
}
