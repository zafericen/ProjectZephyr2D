using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityHolderBase : MonoBehaviour
{
    protected AbilityFragment ability;

    public void InitializeHolder(GameObject attackPerformer)
    {
        InitializeAbilityFragment(attackPerformer);
    }

    public void UseAbility()
    {
        ability.Perform();
    }

    protected abstract void InitializeAbilityFragment(GameObject attackPerformer);
}
