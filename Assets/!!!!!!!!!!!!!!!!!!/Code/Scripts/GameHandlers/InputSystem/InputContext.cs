using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        return new InputContext
        {
            type = InputType.None,
            attackType = AttackInputType.None,
            holdType = InputActionPhase.Disabled,
            inputVector = Vector2.zero
        };
    }

    public bool Equals(InputContext other)
    {
        return type.Equals(other.type) && attackType.Equals(other.attackType);
    }
}