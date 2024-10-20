using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class EnemyCombat : EnemyAction
    {
        public abstract void Attack();

        public abstract void isAttacking();
    }

}
