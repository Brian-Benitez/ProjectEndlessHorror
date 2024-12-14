using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadPlayerInput : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject InputText;

    private string _playersInput;

    public LevelManager LevelManagerRef;
    public SettingsController SettingsControllerRef;
    private void Start()
    {
        DisablePlayersInputText();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))//disable door code UI
        {
            SettingsControllerRef.IsGamePaused = false;
            DisablePlayersInputText();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void DoorCode(string input)
    {
        _playersInput = input;
        Debug.Log(_playersInput);

        if (_playersInput == "0740")
        {
            SettingsControllerRef.IsGamePaused = false;
            LevelManagerRef.RotateSideDoor();
            DisablePlayersInputText();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Debug.Log("play no sound");
            _playersInput = " ";
        }
    }

    public void EnablePlayersInputText()
    {
        SettingsControllerRef.IsGamePaused = true;
        InputText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void DisablePlayersInputText() => InputText.gameObject.SetActive(false);
}
