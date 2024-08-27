using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilitySlotBase : MonoBehaviour
{
    public List<AttackFragment> abilityFragments { get; protected set; }

    public int fragmentIndices { get; set; } = 0;

    public AttackFragment currentFragment { get; set; } = null;

    public void Attack(AttackFragment fragment)
    {
        currentFragment = fragment;
        currentFragment.Perform();
    }

    public virtual void InitializeAbilities(GameObject attackPerformer)
    {
        InitializeAbilityFragment(attackPerformer);
    }

    public bool IsAttacking()
    {
        if (currentFragment != null)
        {
            return !currentFragment.IsAttackFinished();
        }

        return false;
    }

    protected abstract void InitializeAbilityFragment(GameObject attackPerformer);
}
