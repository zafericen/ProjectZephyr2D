//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/Utils/InputSystem/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""0bc1a067-4887-40ee-887a-0fae9c3c8d32"",
            ""actions"": [
                {
                    ""name"": ""Walking"",
                    ""type"": ""Value"",
                    ""id"": ""e05f1375-9f3a-4d35-b42c-97f5e7fe375b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Dodging"",
                    ""type"": ""Button"",
                    ""id"": ""3fd4e0f4-85e0-43d8-b213-58e8aec3e95f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""b18b4fd8-3167-4f8c-9703-9566002b9de0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""26b2b191-9aea-4b7d-9df0-4c226af91916"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c879e5bb-a313-4896-bf03-a9ae025143e9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a5f91744-899c-42e0-b384-e55ec2ab4488"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""5e8e4137-2672-4b9f-a434-063294048d5d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""97128a0f-e93f-4ce1-953e-0e37d6594971"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walking"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""54a1faea-fd04-4d8e-b504-8f6e3891fe32"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dodging"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""32e7686a-4ec9-4f54-82a0-467258a06556"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Attack"",
            ""id"": ""c9e433cc-7f84-4548-833d-5157a592895e"",
            ""actions"": [
                {
                    ""name"": ""Ability"",
                    ""type"": ""Button"",
                    ""id"": ""d2f70d9b-1e95-42b5-82ad-2656fb749789"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""WeaponArt"",
                    ""type"": ""Button"",
                    ""id"": ""b77d0c8d-2e00-4135-a572-e9cb9dc567d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""SpecialAttack"",
                    ""type"": ""Button"",
                    ""id"": ""9ffec3ad-e2a9-4abd-80d6-e5f737fa4940"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""NormalAttack"",
                    ""type"": ""Button"",
                    ""id"": ""0c306810-4cd7-4893-a961-881951b7e94c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""LookDir"",
                    ""type"": ""Value"",
                    ""id"": ""9a8c739c-d282-4055-b4c5-51f373bb817c"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8108a61e-b1b7-4d05-a003-f6dc301e6a2f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NormalAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""288abfcd-5d1d-47f3-adb2-7573945d29ef"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpecialAttack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfa466e3-75bc-44e5-b5a7-76f8b071e47e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WeaponArt"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18043223-2fd1-4292-b3a5-70743966cebc"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""e2ad5dcc-9cae-4ab0-862a-10a9a27a68ad"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5333a494-7608-49c6-87b0-8de82b504e5d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f99560e6-c585-47f8-9912-1896e298ec7d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f07caa37-969b-4c48-be90-78c8a7de1124"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e7f06aef-4663-40a2-83b5-94ecd6e72795"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LookDir"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Walking = m_Movement.FindAction("Walking", throwIfNotFound: true);
        m_Movement_Dodging = m_Movement.FindAction("Dodging", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        // Attack
        m_Attack = asset.FindActionMap("Attack", throwIfNotFound: true);
        m_Attack_Ability = m_Attack.FindAction("Ability", throwIfNotFound: true);
        m_Attack_WeaponArt = m_Attack.FindAction("WeaponArt", throwIfNotFound: true);
        m_Attack_SpecialAttack = m_Attack.FindAction("SpecialAttack", throwIfNotFound: true);
        m_Attack_NormalAttack = m_Attack.FindAction("NormalAttack", throwIfNotFound: true);
        m_Attack_LookDir = m_Attack.FindAction("LookDir", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private List<IMovementActions> m_MovementActionsCallbackInterfaces = new List<IMovementActions>();
    private readonly InputAction m_Movement_Walking;
    private readonly InputAction m_Movement_Dodging;
    private readonly InputAction m_Movement_Jump;
    public struct MovementActions
    {
        private @PlayerInputActions m_Wrapper;
        public MovementActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Walking => m_Wrapper.m_Movement_Walking;
        public InputAction @Dodging => m_Wrapper.m_Movement_Dodging;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void AddCallbacks(IMovementActions instance)
        {
            if (instance == null || m_Wrapper.m_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MovementActionsCallbackInterfaces.Add(instance);
            @Walking.started += instance.OnWalking;
            @Walking.performed += instance.OnWalking;
            @Walking.canceled += instance.OnWalking;
            @Dodging.started += instance.OnDodging;
            @Dodging.performed += instance.OnDodging;
            @Dodging.canceled += instance.OnDodging;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IMovementActions instance)
        {
            @Walking.started -= instance.OnWalking;
            @Walking.performed -= instance.OnWalking;
            @Walking.canceled -= instance.OnWalking;
            @Dodging.started -= instance.OnDodging;
            @Dodging.performed -= instance.OnDodging;
            @Dodging.canceled -= instance.OnDodging;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMovementActions instance)
        {
            foreach (var item in m_Wrapper.m_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Attack
    private readonly InputActionMap m_Attack;
    private List<IAttackActions> m_AttackActionsCallbackInterfaces = new List<IAttackActions>();
    private readonly InputAction m_Attack_Ability;
    private readonly InputAction m_Attack_WeaponArt;
    private readonly InputAction m_Attack_SpecialAttack;
    private readonly InputAction m_Attack_NormalAttack;
    private readonly InputAction m_Attack_LookDir;
    public struct AttackActions
    {
        private @PlayerInputActions m_Wrapper;
        public AttackActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Ability => m_Wrapper.m_Attack_Ability;
        public InputAction @WeaponArt => m_Wrapper.m_Attack_WeaponArt;
        public InputAction @SpecialAttack => m_Wrapper.m_Attack_SpecialAttack;
        public InputAction @NormalAttack => m_Wrapper.m_Attack_NormalAttack;
        public InputAction @LookDir => m_Wrapper.m_Attack_LookDir;
        public InputActionMap Get() { return m_Wrapper.m_Attack; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AttackActions set) { return set.Get(); }
        public void AddCallbacks(IAttackActions instance)
        {
            if (instance == null || m_Wrapper.m_AttackActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_AttackActionsCallbackInterfaces.Add(instance);
            @Ability.started += instance.OnAbility;
            @Ability.performed += instance.OnAbility;
            @Ability.canceled += instance.OnAbility;
            @WeaponArt.started += instance.OnWeaponArt;
            @WeaponArt.performed += instance.OnWeaponArt;
            @WeaponArt.canceled += instance.OnWeaponArt;
            @SpecialAttack.started += instance.OnSpecialAttack;
            @SpecialAttack.performed += instance.OnSpecialAttack;
            @SpecialAttack.canceled += instance.OnSpecialAttack;
            @NormalAttack.started += instance.OnNormalAttack;
            @NormalAttack.performed += instance.OnNormalAttack;
            @NormalAttack.canceled += instance.OnNormalAttack;
            @LookDir.started += instance.OnLookDir;
            @LookDir.performed += instance.OnLookDir;
            @LookDir.canceled += instance.OnLookDir;
        }

        private void UnregisterCallbacks(IAttackActions instance)
        {
            @Ability.started -= instance.OnAbility;
            @Ability.performed -= instance.OnAbility;
            @Ability.canceled -= instance.OnAbility;
            @WeaponArt.started -= instance.OnWeaponArt;
            @WeaponArt.performed -= instance.OnWeaponArt;
            @WeaponArt.canceled -= instance.OnWeaponArt;
            @SpecialAttack.started -= instance.OnSpecialAttack;
            @SpecialAttack.performed -= instance.OnSpecialAttack;
            @SpecialAttack.canceled -= instance.OnSpecialAttack;
            @NormalAttack.started -= instance.OnNormalAttack;
            @NormalAttack.performed -= instance.OnNormalAttack;
            @NormalAttack.canceled -= instance.OnNormalAttack;
            @LookDir.started -= instance.OnLookDir;
            @LookDir.performed -= instance.OnLookDir;
            @LookDir.canceled -= instance.OnLookDir;
        }

        public void RemoveCallbacks(IAttackActions instance)
        {
            if (m_Wrapper.m_AttackActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IAttackActions instance)
        {
            foreach (var item in m_Wrapper.m_AttackActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_AttackActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public AttackActions @Attack => new AttackActions(this);
    public interface IMovementActions
    {
        void OnWalking(InputAction.CallbackContext context);
        void OnDodging(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IAttackActions
    {
        void OnAbility(InputAction.CallbackContext context);
        void OnWeaponArt(InputAction.CallbackContext context);
        void OnSpecialAttack(InputAction.CallbackContext context);
        void OnNormalAttack(InputAction.CallbackContext context);
        void OnLookDir(InputAction.CallbackContext context);
    }
}
