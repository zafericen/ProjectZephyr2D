using ProjectZephyr;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{

    public class EnemyAction : MonoBehaviour
    {
        public virtual float CalculateProbability(EnemyContext context)
        {
            return 1.0f;
        }
    }

}

