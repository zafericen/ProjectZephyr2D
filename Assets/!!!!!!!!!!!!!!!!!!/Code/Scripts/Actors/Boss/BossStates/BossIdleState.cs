using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class BossIdleState : BossStateBase
    {
        public BossIdleState(GameObject o) : base(o)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            busy = false;
        }
        public override void playStateAnimation()
        {
            animator.Play("Idle");
        }
    }
}