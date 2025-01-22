using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera JumpScareCam;
    public Camera InstanceJumpScareCam;


    public void InstanceJumpScareCamOn()
    {
        PlayerCam.gameObject.SetActive(false);
        InstanceJumpScareCam.gameObject.SetActive(true);
    }

    public void InstanceJumpScareCamOff()
    {
        PlayerCam.gameObject.SetActive(true);
        InstanceJumpScareCam.gameObject.SetActive(false);
    }
    /// <summary>
    /// Turn on player cam and turn off jump scare cam.
    /// </summary>
    public void TurnOnPlayerCam()//we need to make a distrintion of what camera we turn on, there is the game timer jumpscare and now a sudden jumpscare cam. Get the srcipts and make a if else
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
