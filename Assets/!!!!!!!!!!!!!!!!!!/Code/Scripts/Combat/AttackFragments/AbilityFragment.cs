using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public abstract class AbilityFragment : AttackFragment
    {
        protected AbilityFragment(GameObject o, AnimatorOverrideController overrideController) : base(o, overrideController)
        {
        }
    }
}