using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  


public class TestingInputSystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private DeliveryDriver deliveryDriver;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        deliveryDriver = new DeliveryDriver();
        deliveryDriver.Player.Enable();


        deliveryDriver.Player.Move.performed += DeliveryDriver_Movement;
    }

    private void FixedUpdate()
    {
        //Vector2 inputVector = deliveryDriver.Player.Movement.ReadValue<Vector2>();
        //float speed = 5f;
        //transform.position += new Vector3(inputVector.x, 0, inputVector.y) * speed * Time.deltaTime;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
    }

    public void DeliveryDriver_Movement(InputAction.CallbackContext callbackContext)
    {
        Debug.Log(callbackContext);
        if (callbackContext.phase == InputActionPhase.Performed)
        {
            Debug.Log("Performed: ");
        }
    }
}
