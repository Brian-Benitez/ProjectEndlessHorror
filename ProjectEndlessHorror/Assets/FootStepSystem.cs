using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepSystem : MonoBehaviour
{
    public AudioSource footstep;
    public AudioClip Clip;

    public void PlayFootStepSoundL()
    {
        footstep.pitch = Random.Range(0.8f, 1f);
        footstep.Play();
    }
}
