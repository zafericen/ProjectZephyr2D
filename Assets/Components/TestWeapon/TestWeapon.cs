using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeapon : WeaponBase
{
    protected override void InitializeNormalAttackFragment(GameObject o)
    {
        normalAttackFragments = new List<AttackFragment>
        {
            new LavaSword_NAF(o,"Assets/Components/TestWeapon/AnimatorOverrideControllers/NA_1.overrideController"),
            new LavaSword_NAF(o,"Assets/Components/TestWeapon/AnimatorOverrideControllers/NA_2.overrideController")
        };
    }

    protected override void InitializeSpecialAttackFragment(GameObject o)
    {
        specialAttackFragments = new List<AttackFragment>
        {
            new LavaSword_SAF(o,"Assets/Components/TestWeapon/AnimatorOverrideControllers/SA_1.overrideController"),
            new LavaSword_SAF(o,"Assets/Components/TestWeapon/AnimatorOverrideControllers/SA_2.overrideController")
        };
    }

    protected override void InitializeWeaponArtFragment(GameObject o)
    {
        weaponArtFragments = new List<AttackFragment>
        {
            new LavaSword_WAF(o,"Assets/Components/TestWeapon/AnimatorOverrideControllers/WA_1.overrideController")
        };
    }

    protected override void DealDamage(Health health)
    {
        health.TakeDamage(20 * currentFragment.damageMultiplier, DamageType.NORMAL_DAMAGE);
        Debug.Log("Attacked");
    }
}
