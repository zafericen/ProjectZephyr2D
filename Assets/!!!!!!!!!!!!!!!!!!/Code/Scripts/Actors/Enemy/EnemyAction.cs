using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectZephyr
{
    public interface IEnemyAction
    {
        [SerializeField]
        protected float lastTime { get; }
        [SerializeField]
        protected float timeMultiplier { get; }

        [SerializeField]
        protected float score { get; }
        [SerializeField]
        protected float scoreMultiplier { get; }

        public float Calculate()
        {
            float rawScore = new Vector2(Time.time - lastTime, score).magnitude;
            return Sigmoid(rawScore);
        }

        private float Sigmoid(float x)
        {
            return 1f / (1f + Mathf.Exp(-x));
        }

        public bool Roll()
        {
            float rollResult = Random.Range(0f, 1f);
            return rollResult < Calculate(); 
        }

        protected abstract void Score(); 
    }
}
