
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class EasterEggController : MonoBehaviour
{
    [Header("Duration")]
    public float EasterEggTimer = 5f;
    [Header("Booleans")]
    public bool IsEasterEggEnabled = false;
    [Header("EasterObject")]
    public GameObject EasterEggObject;

    [Header("Scripts")]
    public SettingsController SettingsControllerRef;
    public CameraFade CameraFadeRef;
    public ReadPlayerInput PlayerInputRef;
    public AudioController AudioControllerRef;


 
    public void EnableEasterEggBool() => IsEasterEggEnabled = true;

    public void DisableEasterEggBool() => IsEasterEggEnabled = false;

    public void EasterEggState()
    {
        Debug.Log("play easter egg");
        EasterEggObject.GetComponent<BoxCollider>().enabled = false;
        AudioController.instance.PlayUnlockKeyDoorSound();
        SettingsControllerRef.PausePlayerMovement();
        EnableEasterEggBool();
        PlayerInputRef.DisableEasterEggInputText();
        CameraFadeRef.FadeToBlack();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Delay(EasterEggTimer, () =>
        {
            SettingsControllerRef.UnpausePlayerMovement();
            CameraFadeRef.FadeOffOfBlack();
            Debug.Log("back to normal");
        });
    }

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
