using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace ProjectZephyr
{
    public interface IBackTrackableInput : IPlayerInputActionable
    {
        InputStack<InputContext> inputStack { get; set; }

        NonHashableMap<InputContext, InputAction> inputContextToInputActionMap { get; set; }

        void InitializeInputContextToInputActionMap();

        void InitializeStack();

    }

    public interface IPlayerInputActionable
    {
        PlayerInputActions inputActions { get; set; }

        void InitializeInputActions();
    }

    public interface IInputActionAddable
    {
        IBackTrackableInput trackableInput { get; set; }

        void InitializeInputActionMaps();
    }
}