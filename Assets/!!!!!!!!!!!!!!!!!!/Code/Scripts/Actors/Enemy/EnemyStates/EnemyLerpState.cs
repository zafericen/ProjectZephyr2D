using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public class EnemyLerpState : EnemyStateBase
    {
        EnemyLerp enemyLerp;

        public EnemyLerpState(GameObject o) : base(o)
        {
            enemyLerp = o.GetComponent<EnemyLerp>();
        }

        public override void OnUpdate()
        {
            enemyLerp.Move(enemyBehaviour.context.aims[0].transform);
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }

}
