using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{
    public class PlayerAttackInputHandler : PlayerInputActions.IAttackActions, IInputActionAddable
    {
        public IBackTrackableInput trackableInput { get; set; }

        Vector2 lookDir;
        public PlayerAttackInputHandler(IBackTrackableInput trackableInput)
        {
            this.trackableInput = trackableInput;
            lookDir = Vector2.zero;
            InitializeInputActionMaps();
        }

        public void InitializeInputActionMaps()
        {
            trackableInput.inputActions.Attack.AddCallbacks(this);
        }

        public void OnLookDir(InputAction.CallbackContext context)
        {
            if (context.canceled == true)
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

            trackableInput.inputStack.AddToStack(addContext);
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
            trackableInput.inputStack.AddToStack(addContext);
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
            trackableInput.inputStack.AddToStack(addContext);
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
            trackableInput.inputStack.AddToStack(addContext);
        }
    }
    public class PlayerMovementInputHandler : PlayerInputActions.IMovementActions, IInputActionAddable
    {
        public IBackTrackableInput trackableInput { get; set; }

        public PlayerMovementInputHandler(IBackTrackableInput trackableInput)
        {
            this.trackableInput = trackableInput;

            InitializeInputActionMaps();
        }


        public void InitializeInputActionMaps()
        {
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
            trackableInput.inputStack.AddToStack(addContext);
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

            trackableInput.inputStack.AddToStack(addContext);
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

            trackableInput.inputStack.AddToStack(addContext);
        }

    }
}