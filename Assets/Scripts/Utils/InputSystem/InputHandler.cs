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
    None,
    Normal,
    Special,
    WeaponArt,
    Ability
}

public struct InputContext : IComparable<InputContext>, IEquatable<InputContext>
{
    public InputType type;
    public AttackInputType attackType;
    public InputActionPhase holdType;
    public Vector2 inputVector;
    public int CompareTo(InputContext other)
    {
        return -type.CompareTo(other.type);
    }

    public static InputContext EmptyContext()
    {
        return new InputContext { type = InputType.None, attackType = AttackInputType.None, 
            holdType = InputActionPhase.Disabled, inputVector = Vector2.zero };
    }

    public bool Equals(InputContext other)
    {
        return type.Equals(other.type) && holdType.Equals(other.holdType);
    }
}

public class InputHandler : MonoSingleton<InputHandler>
{

    private Dictionary<Type, InputContext> stateToInputContextMap = new Dictionary<Type, InputContext>
        {
            { typeof(PlayerIdleState), InputContext.EmptyContext() },
            { typeof(PlayerWalkState), new InputContext { type = InputType.Walk, holdType = InputActionPhase.Performed } },
            { typeof(PlayerJumpState), new InputContext { type = InputType.Jump, holdType = InputActionPhase.Performed } },
            { typeof(PlayerDodgeState), new InputContext { type = InputType.Dodge, holdType = InputActionPhase.Performed } },
            { typeof(PlayerAttackState), new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed } },
        };

    public PlayerInput playerInputActions { get; private set; }

    public InputContext[] buffer = new InputContext[12];
    InputContext lastContext = new InputContext { };

    private void Awake()
    {
        playerInputActions = GetComponent<PlayerInput>();
    }

    public InputContext PlayerStateTypeToInputContext(Type type)
    {
        InputContext returnContext = InputContext.EmptyContext();


        if (!stateToInputContextMap.ContainsKey(type))
        {
            return returnContext;
        }

        returnContext = stateToInputContextMap[type];

        return returnContext;
    }

    private void Update()
    {
        AddToBuffer(ConsumeInput());
    }

    public void DodgingCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Dodge; 
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.None;
        lastContext.inputVector = Vector2.zero;
    }

    public void WalkingCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Walk; 
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.None;
        lastContext.inputVector = context.ReadValue<Vector2>();
    }

    public void JumpingCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Jump; 
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.None;
        lastContext.inputVector = Vector2.zero;
    }

    public void NormalAttackCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Attack;
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.Normal;
    }

    public void SpecialAttackCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Attack;
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.Special;
    }

    public void WeaponArtCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Attack;
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.WeaponArt;
    }

    public void AbilityCall(InputAction.CallbackContext context)
    {
        lastContext.type = InputType.Attack;
        lastContext.holdType = context.phase;
        lastContext.attackType = AttackInputType.Ability;
    }

    public bool CheckInput(InputType type, InputActionPhase actionPhase) 
    {
        var input = GetInput(type,actionPhase);
        if (input.type != InputType.None) return true;
        return false;
    }
    public InputContext GetInput(InputType type, InputActionPhase actionPhase)
    {
        if(type == InputType.None && actionPhase == InputActionPhase.Disabled)
        {
            return InputContext.EmptyContext();
        }
        for (int i = buffer.Length-1; i >= 0; i--)
        {
            if (buffer[i].type == type && buffer[i].holdType == actionPhase)
            {
                var returnValue = buffer[i];
                //buffer[i].holdType = InputActionPhase.Disabled;
                return returnValue;
            }
        }
        return InputContext.EmptyContext();
    }

    private InputContext ConsumeInput()
    {
        var returnContext = lastContext;
        if(lastContext.holdType == InputActionPhase.Canceled)
        {

            lastContext.type = InputType.None; 
            lastContext.holdType = InputActionPhase.Disabled;
            lastContext.attackType = AttackInputType.None;
            lastContext.inputVector = Vector2.zero;
        }
        return returnContext;
    }

    private void AddToBuffer(InputContext inputContext)
    {
        for (int i = buffer.Length-1; i > 0; i--)
        {
            buffer[i] = buffer[i-1];
        }
        buffer[0] = inputContext;
    }
}
