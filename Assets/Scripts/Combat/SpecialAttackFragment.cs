using UnityEngine;

namespace ProjectZephyr
{
    public abstract class SpecialAttackFragment : AttackFragment
    {
        protected SpecialAttackFragment(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
        {
        }

    }
}