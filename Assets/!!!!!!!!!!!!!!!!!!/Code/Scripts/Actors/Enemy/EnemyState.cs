using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    /*
     * Each state will be associated with a three-dimensional vector, 
     * which will influence state transitions. 
     * The magnitude of this vector determines the likelihood of the state being selected.
     *
     * 1. The first component represents *possibility*, indicating whether the state is viable (true or false).
     * 2. The second component measures the *time* elapsed since the last state transition.
     * 3. The third component estimates how likely the state is to lead towards the desired target or position.
     */

    public class EnemyState : State
    {
        [SerializeField]
        protected Vector3 behaviourVector;
        [SerializeField]
        protected float viabilityThreshold;
        [SerializeField]
        protected float timeScale = 10.0f;

        protected float elapsedTime = 0;

        protected float calculateTimeComponent()
        {
            float scaledTime = elapsedTime / timeScale;
            return 1f / (1f + Mathf.Exp(-scaledTime));
        }

        protected virtual float calculateAimComponent()
        {
            return 0.5f;
        }

        protected bool IsStateViable()
        {
            float magnitude = behaviourVector.magnitude;

            float randomValue = Random.Range(0f, magnitude);

            float threshold = 0.5f; 
            return randomValue < threshold;
        }
    }

}
