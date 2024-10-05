using UnityEngine;

namespace ProjectZephyr
{
    public abstract class SpecialAttackFragment : AttackFragment
    {
        protected SpecialAttackFragment(GameObject attackPerformer, AnimatorOverrideController overrideController) : base(attackPerformer, overrideController)
        {
        }

    }
}