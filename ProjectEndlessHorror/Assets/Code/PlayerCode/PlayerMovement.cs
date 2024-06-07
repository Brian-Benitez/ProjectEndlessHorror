using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Need to make a new controller, this is ass.
    [Header("Float")]
    public float moveSpeed;
    public float groundDrag;
    public float playerHeight;
    public float GroundDistance = 0.4f;

    [Header("Layer Mask")]
    public LayerMask GroundMask;

    [Header("Bools")]
    bool Isgrounded;

    [Header("Transform")]
    public Transform GroundCheck;
    public Transform Orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        Isgrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        MyInput();
        //handles drag 
        if (Isgrounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }
}
