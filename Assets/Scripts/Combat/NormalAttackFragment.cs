using UnityEngine;

namespace ProjectZephyr
{
    public abstract class NormalAttackFragment : AttackFragment
    {
        protected NormalAttackFragment(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
        {
        }

    }
}
