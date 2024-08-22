using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class LavaSword_SAF : SpecialAttackFragment
    {
        public LavaSword_SAF(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
        {
        }

        public override void ApplyLogic()
        {
            animator.Play(animationName, 0, 0.0f);
        }

    }
}