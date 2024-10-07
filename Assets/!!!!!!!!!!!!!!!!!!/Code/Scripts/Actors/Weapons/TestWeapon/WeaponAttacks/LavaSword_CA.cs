using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class LavaSword_CA : ComboAttackFragment
    {
        public LavaSword_CA(GameObject attackPerformer, AnimatorOverrideController overrideController, List<AttackInputType> comboStream, AttackInputType activasionAttack) : base(attackPerformer, overrideController, comboStream, activasionAttack)
        {
        }

        public override void ApplyLogic()
        {
            animator.Play(animationName, 0, 0.0f);
        }
    }
    
}