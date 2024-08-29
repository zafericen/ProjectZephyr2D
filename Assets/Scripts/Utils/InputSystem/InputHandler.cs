using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ProjectZephyr;

public enum InputType
{
    None,
    Walk,
    Jump,
    Dodge,
    Attack
}

public enum AttackInputType
{
    None
}

public struct InputContext
{
    public InputType type;
    public Vector2 inputVector;
}

public class InputHandler : MonoSingleton<InputHandler>
{
    public PlayerInputActions playerInputActions { get; private set; }
    InputContext buffer;
    Timer timer = new Timer();
    float fadingTime = 5f;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Movement.Enable();
        playerInputActions.Movement.Jump.started += Jump_started;
        playerInputActions.Movement.Walking.started += Walking_started;
        playerInputActions.Movement.Dodging.started += Dodging_started;
        
    }

    private void Update()
    {
        if(buffer.type != InputType.None)Debug.Log(buffer.type);
    }

    private void Dodging_started(InputAction.CallbackContext context)
    {
        buffer = new InputContext { type = InputType.Dodge, inputVector = Vector2.zero };
        timer.Reset();
    }

    private void Walking_started(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        buffer = new InputContext { type = InputType.Walk, inputVector = value };
        timer.Reset();
    }

    private void Jump_started(InputAction.CallbackContext context)
    {
        buffer = new InputContext {type = InputType.Jump, inputVector = Vector2.zero};
        timer.Reset();
    }

    public bool CheckInput(InputType type)
    {
        if (timer.Seconds() > fadingTime) ConsumeInput();

        return type == buffer.type;
    }

    public InputContext ConsumeInput()
    {
        var returnBuffer = buffer;
        buffer = new InputContext { type = InputType.None, inputVector = Vector2.zero };
        return returnBuffer;
    }
}
