using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayerInput : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject InputText;
    public GameObject LevelThreeDoorText;
    public GameObject EasterEggInputText;

    [Header("Strings")]
    private string _doorCodeNumber = "0740";
    private string _levelThreeDoorNumber = "835";
    private string _easterEggNumber = "122213234313";
    private string _playersInput;

    [Header("Scripts")]
    public LevelManager LevelManagerRef;
    public SettingsController SettingsControllerRef;
    public EasterEggController EasterEggControllerRef;
    public AudioController AudioControllerRef;

    private void Start()
    {
        DisablePlayersInputText();
        DisableEasterEggInputText();
        DisableLevelThreeInputText();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))//disable door code UI
        {
            SettingsControllerRef.IsGamePaused = false;
            DisablePlayersInputText();
            DisableEasterEggInputText();
            DisableLevelThreeInputText();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void DoorCode(string input)
    {
        _playersInput = input;
        Debug.Log(_playersInput);

        if (_playersInput == _doorCodeNumber)
        {
            SettingsControllerRef.IsGamePaused = false;
            LevelManagerRef.RotateSideDoor();
            DisablePlayersInputText();
            AudioControllerRef.SecurityOfficeSound();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            AudioControllerRef.PlayUnlockKeyDoorSound();
            LevelManagerRef.LevelTwoKeyPadBoxColldierTurnOff();
        }
        else
        {
            Debug.Log("play no sound");
            _playersInput = " ";
        }
    }

    public void LevelThreeDoorCode(string input)
    {
        _playersInput = input;

        if(_playersInput == _levelThreeDoorNumber)
        {
            SettingsControllerRef.IsGamePaused = false;
            LevelManagerRef.OpenLevelThreeDoor();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DisableLevelThreeInputText();
            AudioControllerRef.PlayUnlockKeyDoorSound();
            LevelManagerRef.LevelThreeKeyPadBoxColldierTurnOff();
        }
        else
        {
            _playersInput = " ";
            Debug.Log("play error sound");
        }
    }

    public void EasterEggCode(string code)
    {
        _playersInput = code;

        if (_playersInput == _easterEggNumber)
            EasterEggControllerRef.EasterEggState();
        else
            _playersInput = " ";
    }

    public void EnableEasterEggUI()
    {
        SettingsControllerRef.PausePlayerInput();
        EasterEggInputText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void EnablePlayersInputText()
    {
        SettingsControllerRef.IsGamePaused = true;
        InputText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioControllerRef.PlayPressKeyPadSound();
    }

    public void EnableLevelThreeInputText()
    {
        SettingsControllerRef.PausePlayerInput();
        LevelThreeDoorText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioControllerRef.PlayPressKeyPadSound();
    }
    public void DisablePlayersInputText() => InputText.gameObject.SetActive(false);
    public void DisableEasterEggInputText() => EasterEggInputText.gameObject.SetActive(false);
    public void DisableLevelThreeInputText() => LevelThreeDoorText.gameObject.SetActive(false);

}
