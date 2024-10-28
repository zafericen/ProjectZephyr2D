using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{
    public class EnemyPathState : EnemyStateBase
    {
        EnemyPath enemyPath;

        public EnemyPathState(GameObject o) : base(o)
        {
            enemyPath = o.GetComponent<EnemyPath>();
        }

        public override void OnUpdate()
        {
            enemyPath.Move(enemyBehaviour.context.aims[0].transform);
            base.OnUpdate();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }

}
