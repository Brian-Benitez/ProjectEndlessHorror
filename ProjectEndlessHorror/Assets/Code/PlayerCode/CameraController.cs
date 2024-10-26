using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera JumpScareCam;

    /// <summary>
    /// Turn on player cam and turn off jump scare cam.
    /// </summary>
    public void TurnOnPlayerCam()
    {
        JumpScareCam.gameObject.SetActive(false);
        PlayerCam.gameObject.SetActive(true);
    }
    /// <summary>
    /// Turn on jump scare cam and turn off player cam.
    /// </summary>
    public void TurnOnJumpScareCam()
    {
        PlayerCam.gameObject.SetActive(false);
        JumpScareCam.gameObject.SetActive(true);
    }
}
