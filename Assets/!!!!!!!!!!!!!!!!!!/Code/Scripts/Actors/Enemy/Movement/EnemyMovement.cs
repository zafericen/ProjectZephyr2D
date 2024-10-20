using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class EnemyMovement : EnemyAction
    {
        public abstract void Move(Transform destination);
    }
}
