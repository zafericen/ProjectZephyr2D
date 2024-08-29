using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ProjectZephyr;
using System;

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

public struct InputContext : IComparable<InputContext>, IEquatable<InputContext>
{
    public InputType type;
    public InputActionPhase holdType;
    public Vector2 inputVector;
    public int CompareTo(InputContext other)
    {
        return -type.CompareTo(other.type);
    }

    public bool Equals(InputContext other)
    {
        return type.Equals(other.type);
    }
}

public class InputHandler : MonoSingleton<InputHandler>
{
    public PlayerInput playerInputActions { get; private set; }

    private InputContext[] buffer = new InputContext[50];
    InputContext lastContext;

    private void Awake()
    {
        playerInputActions = GetComponent<PlayerInput>();
        
    }

    private void Update()
    {
        AddToBuffer(ConsumeInput());
    }

    public void DodgingCall(InputAction.CallbackContext context)
    {
        lastContext = new InputContext { type = InputType.Dodge, holdType = context.phase };
    }

    public void WalkingCall(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();
        lastContext = new InputContext { type = InputType.Walk, holdType = context.phase ,inputVector = value };
    }

    public void JumpingCall(InputAction.CallbackContext context)
    {
        lastContext = new InputContext { type = InputType.Jump, holdType = context.phase };
    }

    public bool CheckInput(InputType type, InputActionPhase actionPhase) 
    {
        var input = GetInput(type,actionPhase);
        if (input.type != InputType.None) return true;
        return false;
    }
    public InputContext GetInput(InputType type, InputActionPhase actionPhase)
    {
        for (int i = 0; i < buffer.Length; i++)
        {
            if (buffer[i].type == type && buffer[i].holdType == actionPhase)
            {
                var returnValue = buffer[i];
                buffer[i].holdType = InputActionPhase.Disabled;
                return returnValue;
            }
        }
        return new InputContext { type = InputType.None };
    }

    public InputContext ConsumeInput()
    {
        var returnContext = lastContext;
        lastContext = new InputContext { type = InputType.None, holdType = InputActionPhase.Disabled};
        return returnContext;
    }

    private void AddToBuffer(InputContext inputContext)
    {
        for (int i = 0; i < buffer.Length-1; i++)
        {
            buffer[i + 1] = buffer[i];
        }
        buffer[0] = inputContext;
    }
}
