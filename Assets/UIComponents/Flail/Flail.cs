using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flail : WeaponBase
{
    public Sprite weaponSprite;
    protected override void InitializeNormalAttackFragment(GameObject o)
    {
        normalAttackFragments = new CurcilarLinkedList<AttackFragment>( new List<AttackFragment>
        {
            new LavaSword_NAF(o,"Assets/Components/Flail/AnimatorOverrideControllers/NA_1.overrideController"),
        });
    }

    protected override void InitializeSpecialAttackFragment(GameObject o)
    {
        specialAttackFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_SAF(o,"Assets/Components/Flail/AnimatorOverrideControllers/SA_1.overrideController"),
        });
    }

    protected override void InitializeWeaponArtFragment(GameObject o)
    {
        weaponArtFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_WAF(o,"Assets/Components/Flail/AnimatorOverrideControllers/WA_1.overrideController"),
        });
    }

    protected override void DealDamage(Health health)
    {
        health.TakeDamage(20 * currentFragment.damageMultiplier, DamageType.NORMAL_DAMAGE);
        Debug.Log("Attacked");
    }
}
