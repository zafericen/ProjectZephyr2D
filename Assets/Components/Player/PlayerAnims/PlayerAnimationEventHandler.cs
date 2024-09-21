using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEventHandler : MonoBehaviour, IInvincible, IAttacking
{
    bool isInvincible;
    bool isAttacking;

    public void Attacking()
    {
        isAttacking = true;
        Debug.Log(isAttacking);
    }

    public bool IsAttacking()
    {
        return isAttacking;
    }

    public void NotAttacking()
    {
        isAttacking = false;
    }
    public bool IsInvincible()
    {
        return isInvincible;
    }

    public void MakeInvincible()
    {
        Debug.Log("IsInvincible");
    }

    public void TakeInvincible()
    {
        isInvincible = false;
    }
}

interface IInvincible
{
    public bool IsInvincible();

    public void MakeInvincible();

    public void TakeInvincible();
}

interface IAttacking
{
    public bool IsAttacking();

    public void Attacking();

    public void NotAttacking();
}

interface IPerfectAttacking
{

}