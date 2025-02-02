using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    private Rigidbody rigidbody;
    private bool isGrounded;
    
    private Vector3 movement;
    private PlayerAnimationController playerAnimationController;

    public Vector3 Movement
    {
        get { return movement; }
        set { movement = value; }
    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerAnimationController = GetComponent<PlayerAnimationController>();
    }

    private void Move(Vector3 movementDirection)
    {
        rigidbody.velocity = new Vector3(movementDirection.x * speed, rigidbody.velocity.y, movementDirection.z * speed);
        playerAnimationController.MoveAnimation();
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rigidbody.AddForce(new Vector3(rigidbody.velocity.x, jumpForce), ForceMode.Impulse);
            playerAnimationController.JumpAnimation(rigidbody.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        Move(movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
