using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class EnemyCombat : EnemyAction
    {
        public abstract void Attack();

        public abstract void isAttacking();

        public override float CalculateProbability(EnemyContext context)
        {
            int attackCount = 0;
            foreach (var actionType in context.actionBuffer)
            {
                if (typeof(EnemyCombat).IsAssignableFrom(actionType))
                {
                    attackCount++;
                }
            }

            if (attackCount > 3)
            {
                return 0f;
            }

            if (context.aims.Count > 0 && context.aims[0] != null)
            {
                float distance = Vector3.Distance(context.enemy.transform.position,
                    context.aims[0].transform.position);

                if (distance < context.attackDistance)
                {
                    return 0.7f;
                }
            }

            return 0f;
        }
    }

}
