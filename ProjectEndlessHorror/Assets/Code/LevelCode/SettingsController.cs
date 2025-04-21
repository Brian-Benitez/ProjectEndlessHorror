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

    [Header("More UI")]
    public List<GameObject> KeyPadPrefab;
    public List<GameObject> LorePagesPrefab;

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
            PausePlayerMovement();
            SettingsPrefab.SetActive(true);
            DisableCreditsMenuPrefab();
            AudioControllerRef.PlayOnSettingClickSound();
        }
        else if(Input.GetKeyUp(KeyCode.Tab) && IsGamePaused)
        {
            UnpausePlayerMovement();
            SettingsPrefab.SetActive(false);
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
        VolumeTextAmount.text = "" + VolumeSlider.value.ToString("0.00");

        ColorAdjustmentsRef.postExposure.value = BrightnessSlider.value;
        BrightnessTextAmount.text = "" + BrightnessSlider.value.ToString("0.00");
    }

    public void ChangeVolume() => AudioController.instance.AdjustAllVolume(VolumeSlider.value);

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
    /// Closes the game.
    /// </summary>
    public void QuitGame() => Application.Quit();
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

    public void PausePlayerMovement()
    {
        PausePlayerInput();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void UnpausePlayerMovement()
    {
        UnPausePlayersInput();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void PausePlayerInput() => IsGamePaused = true;
    public void UnPausePlayersInput() => IsGamePaused = false;


    public void DisableSettingsTexts() => SettingsMenuPrefab.SetActive(false);
    private void EnableSettingsTexts() => SettingsMenuPrefab.SetActive(true);
    public void DisableCreditsMenu() => CreditMenuPrefab.SetActive(false);
    private void EnableCreditsMenu() => CreditMenuPrefab.SetActive(true);

    public void DisableKeyPadMenu() => KeyPadPrefab.ForEach(x => x.SetActive(false));
    public void DisableLorePagesText() => LorePagesPrefab.ForEach(x => x.SetActive(false));


}
