using UnityEngine;

namespace ProjectZephyr
{
    public abstract class NormalAttackFragment : AttackFragment
    {
        protected NormalAttackFragment(GameObject attackPerformer, string AnimatorPath) : base(attackPerformer, AnimatorPath)
        {
        }

    }
}
