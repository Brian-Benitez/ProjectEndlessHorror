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

    private void Start()
    {
        DisablePlayersInputText();
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
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
            LevelManagerRef.RotateSideDoor();
            DisablePlayersInputText();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
            Debug.Log("play no sound");
    }

    public void EnablePlayersInputText()
    {
        InputText.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void DisablePlayersInputText() => InputText.gameObject.SetActive(false);
}
