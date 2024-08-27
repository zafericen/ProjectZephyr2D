using UnityEngine;

namespace ProjectZephyr
{
    public abstract class SpecialAttackFragment : AttackFragment
    {
        protected SpecialAttackFragment(GameObject attackPerformer, string AnimatorPath) : base(attackPerformer, AnimatorPath)
        {
        }

    }
}