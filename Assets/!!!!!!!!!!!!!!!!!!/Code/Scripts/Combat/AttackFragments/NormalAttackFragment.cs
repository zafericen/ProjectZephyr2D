using UnityEngine;

namespace ProjectZephyr
{
    public abstract class NormalAttackFragment : AttackFragment
    {
        protected NormalAttackFragment(GameObject attackPerformer, AnimatorOverrideController overrideController) : base(attackPerformer, overrideController)
        {
        }

    }
}
