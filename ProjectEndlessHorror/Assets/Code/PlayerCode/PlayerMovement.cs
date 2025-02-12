using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController Controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float Runspeed = 16;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;

    [Header("Scripts")]
    public SettingsController SettingsControllerRef;
    public AudioController AudioControllerRef;  


    // Update is called once per frame
    void Update()
    {
        if (SettingsControllerRef.IsGamePaused)
            return;
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }


            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            Controller.Move(move * speed * Time.deltaTime);


            if (Input.GetKey(KeyCode.LeftShift))
            {
                Controller.Move(move * Runspeed * Time.deltaTime);
            }

            velocity.y += gravity * Time.deltaTime;

            Controller.Move(velocity * Time.deltaTime);

            //Sound of footsteps here. if it dont work, its propbably because its in update
            if (move != Vector3.zero)
                AudioControllerRef.PlayerFootStepAudioPlay();
            else
                AudioControllerRef.StopPlayingFootStep();

        }
    }
}
