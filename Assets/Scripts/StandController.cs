using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class StandController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("The speed of the cart's forward/backward movement.")]
    public float moveSpeed = 10f;
    [Tooltip("The turning speed of the cart.")]
    public float turnSpeed = 100f;
    [Tooltip("The rate at which the cart decelerates when there's no input.")]
    public float deceleration = 5f; // Still useful for gradually stopping the cart

    private Rigidbody rb;
    private float verticalInput;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody not found on the cart object. Please add a Rigidbody component.");
            enabled = false; // Disable the script if Rigidbody is missing
        }
    }

    void Update()
    {
        // Get input from keyboard
        verticalInput = Input.GetAxis("Vertical");   // "W" or "Up Arrow" for forward, "S" or "Down Arrow" for backward
        horizontalInput = Input.GetAxis("Horizontal"); // "A" or "Left Arrow" for left, "D" or "Right Arrow" for right
    }

    void FixedUpdate()
    {
        // Use FixedUpdate for physics operations

        // Forward/Backward Movement
        // Directly setting the Rigidbody's velocity along its local Z-axis
        Vector3 targetVelocity = transform.forward * verticalInput * moveSpeed;
        Vector3 currentVelocity = rb.velocity;
        Vector3 velocityChange = targetVelocity - currentVelocity;

        // Ignore changes in Y (gravity is handled by Rigidbody)
        velocityChange.y = 0; 
        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        // Apply deceleration if no forward/backward input
        if (Mathf.Abs(verticalInput) < 0.1f && rb.velocity.magnitude > 0.1f)
        {
            Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(-horizontalVelocity.normalized * deceleration, ForceMode.Acceleration);
        }

        // Turning Left/Right
        float turnAmount = horizontalInput * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turnAmount, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}
