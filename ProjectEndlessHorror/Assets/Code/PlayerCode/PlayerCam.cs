using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [Header("Players Sens")]
    public float sensX = 50;
    public float sensY = 50;

    public Transform PlayerBody;

    float xRotation;
    float yRotation;

    [Header("Script")]
    public SettingsController SettingsControllerRef;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(SettingsControllerRef.IsSettingMenuOpen)
            return;
        else
        {
            //Changed Time.deltaTime to fixed to fix jidder of camera.
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            //rotate cam and orientation
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            PlayerBody.Rotate(Vector3.up * mouseX);

        }
    }
}
