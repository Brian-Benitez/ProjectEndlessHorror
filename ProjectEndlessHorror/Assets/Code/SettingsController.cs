using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    [Header("Slider")]
    public Slider AimSensSlider;
    public Slider VolumeSlider;
    [Header("Texts")]
    public TextMeshProUGUI AimSensTextAmount;
    public TextMeshProUGUI VolumeTextAmount;
    [Header("Settings Prefab")]
    public GameObject SettingsPrefab;
    [Header("Crosshair")]
    public GameObject PlayersCrossHair;
    [Header("Toggle")]
    public Toggle CrosshairToggle;
    [Header("Booleans")]
    public bool IsSettingMenuOpen = false;

    //private void Start() => SettingsPrefab.SetActive(false);

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab) && !IsSettingMenuOpen)//Dont use esc it thows it off when in edtior:(
        {
            SettingsPrefab.SetActive(true);
            IsSettingMenuOpen = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else if(Input.GetKeyUp(KeyCode.Tab) && IsSettingMenuOpen)
        {
            IsSettingMenuOpen = false;
            SettingsPrefab.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ChangeVisualSettings()
    {
        AimSensTextAmount.text = "" + AimSensSlider.value;
        VolumeTextAmount.text = "" + VolumeSlider.value;
        Debug.Log("ayyee");
    }

    public void EnableCross()
    {
        if(CrosshairToggle.isOn)
            PlayersCrossHair.SetActive(true);
        else
            PlayersCrossHair.SetActive(false);
    }

}
