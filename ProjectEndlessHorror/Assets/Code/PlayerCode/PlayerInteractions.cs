using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
   //How this works,
   //The player shoots a raycast on the door.
   //Then in looping room mechanic, it will check to see if everything is done in the room.
   //If it is, spawn new room, then player goes through.

    void Update()
    {
        //player input
        Ray ray = new Ray(transform.position, transform.forward);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if(hit.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
                {
                    interactable.Interact();
                }
            }
        }
    }
}
