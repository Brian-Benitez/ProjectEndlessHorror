using Cinemachine.PostFX;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Slider")]
    public Slider AimSensSlider;
    public Slider VolumeSlider;
    public Slider BrightnessSlider;

    [Header("Texts")]
    public TextMeshProUGUI AimSensTextAmount;
    public TextMeshProUGUI VolumeTextAmount;
    public TextMeshProUGUI BrightnessTextAmount;

    [Header("Settings Prefab")]
    public GameObject SettingsPrefab;
    public GameObject SettingsMenuPrefab;
    public GameObject CreditMenuPrefab;

    [Header("Crosshair")]
    public GameObject PlayersCrossHair;

    [Header("Toggle")]
    public Toggle CrosshairToggle;

    [Header("Booleans")]
    public bool IsGamePaused = false;

    [Header("Profile")]
    private ColorAdjustments ColorAdjustmentsRef;
    public CinemachineVolumeSettings cinemachineVolumeSettingsRef;

    [Header("Start values")]
    public int XSenOrginal = 50;
    public int YSenOrginal = 50;
    public int VolumeOrginal = 5;
    public float BrightnessOrginal = .25f;

    //public List<> AudioSources;
    //AudioSource.Volume and you set what sound it is.

    [Header("Scripts")]
    public PlayerCam PlayerCamRef;
    public AudioController AudioControllerRef;
    private void Start()
    {
        cinemachineVolumeSettingsRef.m_Profile.TryGet<ColorAdjustments>(out ColorAdjustmentsRef);
        ChangeSettings();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab) && !IsGamePaused)//Dont use esc it thows it off when in edtior:(
        {
            SettingsPrefab.SetActive(true);
            IsGamePaused = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            DisableCreditsMenuPrefab();
            AudioControllerRef.PlayOnSettingClickSound();
        }
        else if(Input.GetKeyUp(KeyCode.Tab) && IsGamePaused)
        {
            IsGamePaused = false;
            SettingsPrefab.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AudioControllerRef.PlayOnSettingClickSound();
        }
    }
    /// <summary>
    /// Changes all settings to whatever the player chooses.
    /// </summary>
    public void ChangeSettings()
    {
        //Player sens values here.
        AimSensTextAmount.text = "" + AimSensSlider.value;
        PlayerCamRef.sensX = AimSensSlider.value;
        PlayerCamRef.sensY = AimSensSlider.value;
        //Volume values here.
        VolumeTextAmount.text = "" + VolumeSlider.value;

        ColorAdjustmentsRef.postExposure.value = BrightnessSlider.value;
        BrightnessTextAmount.text = "" + BrightnessSlider.value.ToString("0.00");
    }
    /// <summary>
    /// Disables the settings menu and shows the credits menu.
    /// </summary>
    public void EnableCreditsMenuPrefab()
    {
        DisableSettingsTexts();
        EnableCreditsMenu();
    }
    /// <summary>
    /// Turns off credits menu and enbales the settings again.
    /// </summary>
    public void DisableCreditsMenuPrefab()
    {
        DisableCreditsMenu();
        EnableSettingsTexts();
    }
    /// <summary>
    /// Turns crosshair on or off.
    /// </summary>
    public void EnableCross()
    {
        if(CrosshairToggle.isOn)
            PlayersCrossHair.SetActive(true);
        else
            PlayersCrossHair.SetActive(false);
    }

    public void PausePlayerInput() => IsGamePaused = true;
    public void UnPausePlayersInput() => IsGamePaused = false;

    ////Private functions below!++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void DisableSettingsTexts() => SettingsMenuPrefab.SetActive(false);
    private void EnableSettingsTexts() => SettingsMenuPrefab.SetActive(true);
    private void DisableCreditsMenu() => CreditMenuPrefab.SetActive(false);
    private void EnableCreditsMenu() => CreditMenuPrefab.SetActive(true);

}
