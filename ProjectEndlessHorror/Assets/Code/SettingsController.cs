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

    //private void Start() => SettingsPrefab.SetActive(false);

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SettingsPrefab.SetActive(true);
        
        }
               
    }

    public void ChangeVisualSettings()
    {
        AimSensTextAmount.text = "" + AimSensSlider.value;
        VolumeTextAmount.text = "" + VolumeSlider.value;
        Debug.Log("ayyee");
    }

}
