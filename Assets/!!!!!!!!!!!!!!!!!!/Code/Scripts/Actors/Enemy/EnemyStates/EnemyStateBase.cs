using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class EnemyStateBase : MonoState
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

        public bool Roll(float probability)
        {
            return Random.value <= probability;
        }
    }

}

