using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ProjectZephyr;
using System;
using System.Linq;

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
        return type.Equals(other.type) && holdType.Equals(other.holdType) && attackType.Equals(other.attackType);
    }
}

public class InputHandler : MonoSingleton<InputHandler>, IBackTrackableInput
{
    private Dictionary<Type, InputContext> stateToInputContextMap = new Dictionary<Type, InputContext>
        {
            { typeof(PlayerIdleState), InputContext.EmptyContext() },
            { typeof(PlayerWalkState), new InputContext { type = InputType.Walk, holdType = InputActionPhase.Performed } },
            { typeof(PlayerJumpState), new InputContext { type = InputType.Jump, holdType = InputActionPhase.Performed } },
            { typeof(PlayerDodgeState), new InputContext { type = InputType.Dodge, holdType = InputActionPhase.Performed } },
            { typeof(PlayerAttackState), new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed } },
        };
    public List<InputContext> inputStack { get; set; }
    public PlayerInputActions inputActions { get; set; }

    public InputContext[] buffer = new InputContext[12];
    InputContext lastContext = new InputContext { };



    private void Awake()
    {
        InitializeInputActions();

        InitializeStack();

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
        AddToBuffer(RemoveFromStack());
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
        for (int i = 0; i < buffer.Length; i++)
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

    public void AddToStack(InputContext inputContext)
    {
        if (!inputStack.Exists(x => x.Equals(inputContext)))
        {
            inputStack.Add(inputContext);
            return;
        }

        var locatedInput = inputStack.Find(x => x.Equals(inputContext));

        locatedInput = inputContext;
    }

    public InputContext RemoveFromStack()
    {
        for (int i = inputStack.Count - 1; i > 0; i--)
        {
            if (GetInputActionByInputContext(inputStack[i]).phase == InputActionPhase.Waiting)
            {
                inputStack.RemoveAt(i);
            }
            else
            {
                return inputStack[i];
            }
        }

        return inputStack[0];
    }

    public void InitializeInputActions()
    {
        inputActions = new PlayerInputActions();

        var movementInputHandler = new PlayerMovementInputHandler(this);
        var attackInputHandler = new PlayerAttackInputHandler(this);

    }

    public void InitializeStack()
    {
        inputStack = new List<InputContext>
        {
            InputContext.EmptyContext()
        };
    }

    public InputAction GetInputActionByInputContext(InputContext context)
    {
        if(context.type == InputType.Walk)
        {
            return inputActions.Movement.Walking;
        }
        else if(context.type == InputType.Dodge)
        {
            return inputActions.Movement.Dodging;
        }
        else if(context.type == InputType.Jump)
        {
            return inputActions.Movement.Jump;
        }
        else if(context.type == InputType.Attack && context.attackType == AttackInputType.Ability)
        {
            return inputActions.Attack.Ability;
        }
        else if (context.type == InputType.Attack && context.attackType == AttackInputType.Normal)
        {
            return inputActions.Attack.NormalAttack;
        }
        else if (context.type == InputType.Attack && context.attackType == AttackInputType.Special)
        {
            return inputActions.Attack.SpecialAttack;
        }
        else if (context.type == InputType.Attack && context.attackType == AttackInputType.WeaponArt)
        {
            return inputActions.Attack.WeaponArt;
        }
        else
        {
            return null;
        }
    }
}


public class PlayerAttackInputHandler : PlayerInputActions.IAttackActions, IInputActionAddable
{
    public IBackTrackableInput trackableInput {  get; set; }

    Vector2 lookDir;
    public PlayerAttackInputHandler(IBackTrackableInput trackableInput)
    {
        this.trackableInput = trackableInput;
        lookDir = Vector2.zero;
        InitializeInputActionMaps();
    }

    public void InitializeInputActionMaps()
    {
        trackableInput.inputActions.Attack.Enable();
        trackableInput.inputActions.Attack.AddCallbacks(this);
    }

    public void OnLookDir(InputAction.CallbackContext context)
    {
        if(context.canceled == true)
        {
            lookDir = Vector2.zero;
            return;
        }

        lookDir = context.ReadValue<Vector2>();
    }

    public void OnAbility(InputAction.CallbackContext context)
    {
        InputContext addContext = new()
        {
            type = InputType.Attack,
            holdType = context.phase,
            attackType = AttackInputType.Ability,
            inputVector = lookDir,
        };

        trackableInput.AddToStack(addContext);
    }

    public void OnNormalAttack(InputAction.CallbackContext context)
    {
        InputContext addContext = new InputContext
        {
            type = InputType.Attack,
            holdType = context.phase,
            attackType = AttackInputType.Normal,
            inputVector = lookDir,
        };
        trackableInput.AddToStack(addContext);
    }

    public void OnSpecialAttack(InputAction.CallbackContext context)
    {
        InputContext addContext = new InputContext
        {
            type = InputType.Attack,
            holdType = context.phase,
            attackType = AttackInputType.Special,
            inputVector = lookDir,
        };
        trackableInput.AddToStack(addContext);
    }

    public void OnWeaponArt(InputAction.CallbackContext context)
    {
        InputContext addContext = new InputContext
        {
            type = InputType.Attack,
            holdType = context.phase,
            attackType = AttackInputType.WeaponArt,
            inputVector = lookDir,
        };
        trackableInput.AddToStack(addContext);
    }
}
public class PlayerMovementInputHandler: PlayerInputActions.IMovementActions, IInputActionAddable
{    
    public IBackTrackableInput trackableInput { get; set; }
    
    public PlayerMovementInputHandler(IBackTrackableInput trackableInput)
    {
        this.trackableInput = trackableInput;

        InitializeInputActionMaps();
    }


    public void InitializeInputActionMaps()
    {
        trackableInput.inputActions.Movement.Enable();
        trackableInput.inputActions.Movement.AddCallbacks(this);
    }

    public void OnDodging(InputAction.CallbackContext context)
    {
        InputContext addContext = new InputContext
        {
            type = InputType.Dodge,
            holdType = context.phase,
            attackType = AttackInputType.None,
            inputVector = Vector2.zero
        };
        trackableInput.AddToStack(addContext);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        InputContext addContext = new InputContext
        {
            type = InputType.Jump,
            holdType = context.phase,
            attackType = AttackInputType.None,
            inputVector = Vector2.zero
        };

        trackableInput.AddToStack(addContext);
    }

    public void OnWalking(InputAction.CallbackContext context)
    {
        InputContext addContext = new InputContext
        {
            type = InputType.Walk,
            holdType = context.phase,
            attackType = AttackInputType.None,
            inputVector = context.ReadValue<Vector2>()
        };

        trackableInput.AddToStack(addContext);
    }

}

public interface IBackTrackableInput: IPlayerInputActionable
{
    List<InputContext> inputStack { get; set; }


    InputAction GetInputActionByInputContext(InputContext context);

    void InitializeStack();

    void AddToStack(InputContext inputContext);
    
    InputContext RemoveFromStack();
    
}

public interface IPlayerInputActionable
{
    PlayerInputActions inputActions { get; set; }

    void InitializeInputActions();
}

public interface IInputActionAddable
{
    IBackTrackableInput trackableInput {  get; set; }

    void InitializeInputActionMaps();
}