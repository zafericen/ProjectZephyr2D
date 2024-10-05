using UnityEngine;

namespace ProjectZephyr
{
    public abstract class WeaponArtFragment : AttackFragment
    {
        protected WeaponArtFragment(GameObject attackPerformer, AnimatorOverrideController overrideController) : base(attackPerformer, overrideController)
        { 
        }


    }
}