using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class Flail_NAF : NormalAttackFragment
    {
        public Flail_NAF(GameObject o, AnimatorOverrideController overrideController) : base(o, overrideController)
        {
        }

        public override void ApplyLogic()
        {
            animator.Play(animationName, 0, 0.0f);
        }
    }
}