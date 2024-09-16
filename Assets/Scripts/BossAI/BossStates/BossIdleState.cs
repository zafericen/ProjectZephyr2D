using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossStateBase
{

    public override void OnEnter(MachineContext context)
    {
        base.OnEnter(context);
        status = StateStatus.Success;
    }
    public override void playStateAnimation()
    {
        animator.Play("Idle");
    }
}
