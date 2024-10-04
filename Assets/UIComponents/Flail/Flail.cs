using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flail : WeaponBase
{
    //adapt to WeaponBase
    public Sprite weaponSprite;
    protected override void InitializeNormalAttackFragment(GameObject o)
    {
        normalAttackFragments = new CurcilarLinkedList<AttackFragment>( new List<AttackFragment>
        {
            new Flail_NAF(o,"Assets/UIComponents/Flail/AnimatorOverrideControllers/NA_1.overrideController"),
        });
    }

    protected override void InitializeSpecialAttackFragment(GameObject o)
    {
        specialAttackFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new Flail_SAF(o,"Assets/UIComponents/Flail/AnimatorOverrideControllers/SA_1.overrideController"),
        });
    }

    protected override void InitializeWeaponArtFragment(GameObject o)
    {
        weaponArtFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new Flail_WAF(o,"Assets/UIComponents/Flail/AnimatorOverrideControllers/WA_1.overrideController"),
        });
    }

    
}
