using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class Sword_WAF : WeaponArtFragment
    {
        public Sword_WAF(GameObject o, AnimatorOverrideController overrideController) : base(o, overrideController)
        {
        }

        public override void ApplyLogic()
        {
            animator.Play(animationName, 0, 0f);
        }

    }
}