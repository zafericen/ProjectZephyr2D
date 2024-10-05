using UnityEngine;

namespace ProjectZephyr
{
    public abstract class WeaponArtFragment : AttackFragment
    {
        protected WeaponArtFragment(GameObject attackPerformer, string AnimatorPath) : base(attackPerformer, AnimatorPath)
        { 
        }


    }
}