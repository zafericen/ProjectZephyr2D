using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ProjectZephyr;
using System;
using System.Linq;


namespace ProjectZephyr
{
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
        public InputStack<InputContext> inputStack { get; set; }
        public PlayerInputActions inputActions { get; set; }
        public NonHashableMap<InputContext, InputAction> inputContextToInputActionMap { get; set; }

        public InputContext[] buffer = new InputContext[12];
        InputContext lastContext = new InputContext { };



        private void Awake()
        {
            InitializeInputActions();

            InitializeStack();

            InitializeInputContextToInputActionMap();
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
        {                                                   //InputActionPhase.Disabled = 0 and InputActionPhase.Waiting = 1
                                                            //So checking (int)GetInputActionByContext(x).phase <= 1
                                                            //Its checking if the input is non-available
            AddToBuffer(inputStack.RemoveFromStack(x => (int)GetInputActionByContext(x).phase <= 1));

        }

        public bool CheckInput(InputType type, InputActionPhase actionPhase)
        {
            var input = GetInput(type, actionPhase);
            if (input.type != InputType.None) return true;
            return false;
        }
        public InputContext GetInput(InputType type, InputActionPhase actionPhase)
        {
            if (type == InputType.None && actionPhase == InputActionPhase.Disabled)
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


        private void AddToBuffer(InputContext inputContext)
        {
            for (int i = buffer.Length - 1; i > 0; i--)
            {
                buffer[i] = buffer[i - 1];
            }
            buffer[0] = inputContext;
        }

        public void InitializeInputActions()
        {
            inputActions = new PlayerInputActions();

            EnableAllInputMaps();

            var movementInputHandler = new PlayerMovementInputHandler(this);
            var attackInputHandler = new PlayerAttackInputHandler(this);
        }

        public void DisableInputMaps(params InputActionMap[] toDisableInputActions)
        {
            foreach (var item in toDisableInputActions)
            {
                item.Disable();
            }
        }
        public void EnableInputMaps(params InputActionMap[] toDisableInputActions)
        {
            foreach (var item in toDisableInputActions)
            {
                item.Enable();
            }
        }

        public void EnableAllInputMaps()
        {
            inputActions.Enable();
        }

        public void DisableAllInputMaps(params InputActionMap[] toDisableInputActions)
        {
            inputActions.Disable();
        }

        public void InitializeStack()
        {
            inputStack = new InputStack<InputContext>
        {
            InputContext.EmptyContext()
        };
        }

        InputAction GetInputActionByContext(InputContext context)
        {
            return inputContextToInputActionMap.GetValue(context);
        }

        public void InitializeInputContextToInputActionMap()
        {
            inputContextToInputActionMap = new NonHashableMap<InputContext, InputAction>()
        {
            { new InputContext{type = InputType.Walk, attackType = AttackInputType.None}, inputActions.Movement.Walking},
            { new InputContext{type = InputType.Jump, attackType = AttackInputType.None}, inputActions.Movement.Jump },
            { new InputContext{type = InputType.Dodge, attackType = AttackInputType.None}, inputActions.Movement.Dodging },
            { new InputContext{type = InputType.Attack, attackType = AttackInputType.Normal}, inputActions.Attack.NormalAttack },
            { new InputContext{type = InputType.Attack, attackType = AttackInputType.Special}, inputActions.Attack.SpecialAttack},
            { new InputContext{type = InputType.Attack, attackType = AttackInputType.WeaponArt}, inputActions.Attack.WeaponArt},
            { new InputContext{type = InputType.Attack, attackType = AttackInputType.Ability}, inputActions.Attack.Ability}
        };
        }
    }
}