using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class Flail_WAF : WeaponArtFragment
    {
        public Flail_WAF(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
        {
        }

        public override void ApplyLogic()
        {
            animator.Play(animationName, 0, 0f);
        }

    }
}