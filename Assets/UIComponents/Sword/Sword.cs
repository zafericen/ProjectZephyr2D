using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : WeaponBase
{
    //adapt to WeaponBase
    public Sprite weaponSprite;
    protected override void InitializeNormalAttackFragment(GameObject o)
    {
        normalAttackFragments = new CurcilarLinkedList<AttackFragment>( new List<AttackFragment>
        {
            new LavaSword_NAF(o,"Assets/UIComponents/Sword/AnimatorOverrideControllers/NA_1.overrideController"),
        });
    }

    protected override void InitializeSpecialAttackFragment(GameObject o)
    {
        specialAttackFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_SAF(o,"Assets/UIComponents/Sword/AnimatorOverrideControllers/SA_1.overrideController"),
        });
    }

    protected override void InitializeWeaponArtFragment(GameObject o)
    {
        weaponArtFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_WAF(o,"Assets/UIComponents/Sword/AnimatorOverrideControllers/WA_1.overrideController"),
        });
    }


}
