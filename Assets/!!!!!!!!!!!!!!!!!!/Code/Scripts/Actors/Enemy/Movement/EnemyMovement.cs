using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class EnemyMovement : EnemyAction
    {
        public abstract void Move(Transform destination);

        public override float CalculateProbability(EnemyContext context)
        {
            if (context.aims.Count > 0 && context.aims[0] != null)
            {
                float distance = Vector3.Distance(context.enemy.transform.position,
                    context.aims[0].transform.position);

                if (distance > context.attackDistance)
                {
                    return 0.3f;
                }
            }

            return 0f;
        }
    }
}
