using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityFragment : AttackFragment
{
    protected AbilityFragment(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
    {
    }
}
