using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    private PlayerInput playerInput;
    private DeliveryDriver deliveryDriver;

    public float speed = 5f;
    public float rotationSpeed = 100f;

    private Vector2 moveInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        deliveryDriver = new DeliveryDriver();
        deliveryDriver.Player.Enable();


        deliveryDriver.Player.Move.performed += DeliveryDriver_Movement;
    }

    private void FixedUpdate()
    {
        // Check if the car is moving
        if (moveInput.y != 0)
        {
            // Apply rotation only when the car is moving
            float rotation = -moveInput.x * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotation);
        }

        // Apply movement
        Vector3 movement = transform.up * moveInput.y * speed * Time.deltaTime;
        transform.position += movement;
    }

    public void DeliveryDriver_Movement(InputAction.CallbackContext callbackContext)
    {
        moveInput = callbackContext.ReadValue<Vector2>();
    }
}
