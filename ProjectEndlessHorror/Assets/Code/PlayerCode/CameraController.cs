using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    [Header("Cameras")]
    public CinemachineVirtualCamera PlayerCam;
    public CinemachineVirtualCamera JumpScareCam;
    public Camera InstanceJumpScareCam;

    [Header("Scripts")]
    public MonsterBehavior MonsterBehaviorRef;
    public GameTimer GameTimerRef;
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
    public void TurnOnPlayerCam()
    {
        if(MonsterBehaviorRef.GotJumpScared && GameTimerRef.TimerIsRunning == false)
            InstanceJumpScareCamOff();
        else if(GameTimerRef.TimerIsRunning == true)
            TurnOffTimedJumpScareCam();
    }
    /// <summary>
    /// Turn on jump scare cam and turn off player cam.
    /// </summary>
    public void TurnOnTimedJumpScareCam()
    {
        PlayerCam.gameObject.SetActive(false);
        JumpScareCam.gameObject.SetActive(true);
    }
    public void TurnOffTimedJumpScareCam()
    {
        PlayerCam.gameObject.SetActive(true);
        JumpScareCam.gameObject.SetActive(false);
    }
}
