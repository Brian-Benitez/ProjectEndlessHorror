using interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public SettingsController SettingsControllerRef;

    void Update()
    {
        if (SettingsControllerRef.IsGamePaused)
            return;
        else
        {
            //player input
            Ray ray = new Ray(transform.position, transform.forward);
            
            if (Input.GetMouseButtonDown(0))
            {
                Debug.DrawLine(transform.position, transform.forward);
                Debug.Log("hit hit " + transform.name);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.transform.TryGetComponent<IInteractable>(out IInteractable interactable))
                    {
                        interactable.Interact();
                        Debug.Log("hit");
                    }
                }
            }
        }
    }
}
