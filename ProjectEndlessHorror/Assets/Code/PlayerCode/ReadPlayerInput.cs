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
    [SerializeField] private string DoorCodeNumber = "0740";
    [SerializeField] private string LevelThreeDoorNumber = "835";
    public string EasterEggNumber = " ";

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

        if (_playersInput == DoorCodeNumber)
        {
            SettingsControllerRef.IsGamePaused = false;
            LevelManagerRef.RotateSideDoor();
            DisablePlayersInputText();
            AudioControllerRef.SecurityOfficeSound();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
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

        if(_playersInput == LevelThreeDoorNumber)
        {
            SettingsControllerRef.IsGamePaused = false;
            LevelManagerRef.OpenLevelThreeDoor();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            DisableLevelThreeInputText();

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

        if (_playersInput == EasterEggNumber)
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
    }

    public void EnableLevelThreeInputText()
    {
        SettingsControllerRef.PausePlayerInput();
        LevelThreeDoorText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void DisablePlayersInputText() => InputText.gameObject.SetActive(false);
    public void DisableEasterEggInputText() => EasterEggInputText.gameObject.SetActive(false);
    public void DisableLevelThreeInputText() => LevelThreeDoorText.gameObject.SetActive(false);

}
