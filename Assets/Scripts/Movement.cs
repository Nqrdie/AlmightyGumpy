using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;
    Vector3 movement;
    private GooberState currentState;
    public Animator anim;

    public Camera cameraTest;

    public bool movePossible = true;

    public enum GooberState
    {
        idle,
        walking,
        grab
    }

    private void Start()
    {
        cameraTest = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        if (movePossible)
        {
            // Get the camera's forward and right vectors
            Vector3 cameraForward = cameraTest.transform.forward;
            Vector3 cameraRight = cameraTest.transform.right;

            // Flatten the vectors (ignore the Y axis)
            cameraForward.y = 0f;
            cameraRight.y = 0f;

            // Normalize the vectors
            cameraForward.Normalize();
            cameraRight.Normalize();

            // Input
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");

            // Calculate the movement direction based on camera orientation
            Vector3 moveDirection = cameraForward * movement.z + cameraRight * movement.x;
            moveDirection.Normalize();

            currentState = GooberState.idle;

            // Rotate player based on movement
            if (moveDirection != Vector3.zero)
            {
                currentState = GooberState.walking;
                Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, Time.deltaTime * 500f);
            }

            if (Input.GetKey(KeyCode.E))
            {
                currentState = GooberState.grab;
            }

            anim.SetFloat("State", (float)currentState);

            // Move the player based on the calculated direction
            rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
        }
    }
}