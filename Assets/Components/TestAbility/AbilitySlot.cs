using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySlot : AbilitySlotBase
{
    protected override void InitializeAbilityFragment(GameObject attackPerformer)
    {
        abilityFragments = new List<AttackFragment> {
            new Dash(attackPerformer, "Assets/Components/TestWeapon/AnimatorOverrideControllers/WA_1.overrideController") 
        };
    }
}