using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class Sword_NAF : NormalAttackFragment
    {
        public Sword_NAF(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
        {
        }

        public override void ApplyLogic()
        {
            animator.Play(animationName, 0, 0.0f);
        }
    }
}