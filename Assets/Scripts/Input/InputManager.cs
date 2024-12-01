using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 playerMovement;

    private PlayerInput playerInput;
    private InputAction moveAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
    }

    void Update()
    {
        playerMovement = moveAction.ReadValue<Vector2>();
    }
}
