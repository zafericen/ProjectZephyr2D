using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class EnemyStateBase : MonoState
    {
        protected EnemyBehaviour enemyBehaviour;

        public EnemyStateBase(GameObject o) : base(o)
        {
            enemyBehaviour = o.GetComponent<EnemyBehaviour>();
        }

        public override void OnExit()
        {
            enemyBehaviour.CalculateProbabilities();
        }
    }

}

