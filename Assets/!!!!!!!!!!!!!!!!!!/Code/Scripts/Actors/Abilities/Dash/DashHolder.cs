using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class DashHolder: AbilityHolderBase
    {
        protected override void InitializeAbilityFragment(GameObject attackPerformer)
        {
            ability = new Dash(attackPerformer, overrideController);
        }
    }
}