using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class EnemyIdleState : EnemyStateBase
    {
        public EnemyIdleState(GameObject o) : base(o)
        {
        }

        public override void OnEnter()
        {
            base.OnEnter();
            busy = false;
        }

        public virtual float CalculateProbability(EnemyContext context)
        {
            return 0.5f;
        }
    }

}