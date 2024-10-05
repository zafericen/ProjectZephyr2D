using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectZephyr
{
    public class TestWeapon : WeaponBase
    {
        protected override void InitializeNormalAttackFragment(GameObject o)
        {
            normalAttackFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_NAF(o,GetOverrideFromList(Attacks.NA,0)),
        });
        }

        protected override void InitializeSpecialAttackFragment(GameObject o)
        {
            specialAttackFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_SAF(o,GetOverrideFromList(Attacks.SA,0)),
        });
        }

        protected override void InitializeWeaponArtFragment(GameObject o)
        {
            weaponArtFragments = new CurcilarLinkedList<AttackFragment>(new List<AttackFragment>
        {
            new LavaSword_WAF(o,GetOverrideFromList(Attacks.WA,0)),
        });
        }
    }
}