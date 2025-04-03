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
    [Header("Footsteps parameter")]
    public bool IsMoving;
    public AudioSource FootStepAudioSource;
    public AudioClip[] FootStepAudioClip;
    public float WalkStepInterval = 0.5f;
    public float SprintStepInterval = 0.3f;
    public float VelocityThreshold = 2.0f;

    public float nextSteptime;
    public int OldFSIndex = 0;





    [Header("Scripts")]
    public SettingsController SettingsControllerRef;


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

            IsMoving = z != 0 || x != 0;
            Debug.Log(IsMoving);

        }
        HandleFootSteps();
    }

    private void HandleFootSteps()
    {
       float currentStepInterval = Input.GetKey(KeyCode.LeftShift) ? SprintStepInterval : WalkStepInterval;
        if(IsMoving && Time.time > nextSteptime)
        {
            FootStepSound();
            nextSteptime = Time.time + currentStepInterval;
        }
    }

    void FootStepSound()
    {
        int NewIndex = OldFSIndex;
        if (OldFSIndex == 1)//right foot
        {
            NewIndex = 0;
        }
        else if (OldFSIndex == 0)//left foot
        {
            NewIndex = 1;
        }
        OldFSIndex = NewIndex;

        FootStepAudioSource.clip = FootStepAudioClip[NewIndex];
        FootStepAudioSource.Play();
    }
}
