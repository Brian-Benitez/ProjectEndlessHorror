using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public interface IInteractable
    {
        public void Interact();
    }
}
