using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Dash : AbilityFragment
{
    public Dash(GameObject o, string AnimatorPath) : base(o, AnimatorPath)
    {
    }

    public override void ApplyLogic()
    {
        animator.Play(animationName, 0, 0.0f);
        attackPerformer.GetComponent<Rigidbody2D>().velocity = new Vector2
            (5*Mathf.Sign(attackPerformer.transform.localScale.x), 5);  
    }
}
