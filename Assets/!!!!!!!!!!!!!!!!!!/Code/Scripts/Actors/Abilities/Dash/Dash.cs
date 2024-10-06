using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace ProjectZephyr
{
    public class Dash: AbilityFragment
    {
        public Dash(GameObject o, AnimatorOverrideController overrideController) : base(o, overrideController)
        {
        }

        public override void ApplyLogic()
        {
            attackPerformer.GetComponent<Rigidbody2D>().velocity = new Vector2
                (5 * Mathf.Sign(attackPerformer.transform.localScale.x), 5);
        }
    }
}