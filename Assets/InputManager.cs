using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static event System.Action OnJump;
    public static event System.Action<Vector2> OnPlayerMovement;
    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= HandleInput;
    }

    private void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {
            case "Move":

                Vector2 input = context.ReadValue<Vector2>();
                OnPlayerMovement?.Invoke(input);
                break;

            case "Jump":
                if (context.started) OnJump?.Invoke(); break;
        }
    }
}
