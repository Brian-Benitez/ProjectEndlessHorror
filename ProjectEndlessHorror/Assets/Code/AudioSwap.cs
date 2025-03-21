using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioController.instance.isPlayingMainAmbience = true;
            AudioController.instance.SwapTracks();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioController.instance.isPlayingMainAmbience = false;
            AudioController.instance.SwapTracks();
        }
    }
}
