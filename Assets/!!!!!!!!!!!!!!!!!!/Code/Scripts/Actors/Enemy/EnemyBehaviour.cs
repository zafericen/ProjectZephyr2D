using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

namespace ProjectZephyr
{

    public class EnemyContext
    {
        public List<GameObject> aims = new List<GameObject>(); 
        public int primaryAimIndex = 0; 

        public Queue<Type> actionBuffer = new Queue<Type>(5);

        public void AddAction(Type actionType)
        {
            if (actionBuffer.Count >= 5)
            {
                actionBuffer.Dequeue(); 
            }
            actionBuffer.Enqueue(actionType); 
        }

        public Type GetAction(int index)
        {
            return new List<Type>(actionBuffer)[index];
        }
    }

    public class EnemyBehaviour : MonoBehaviour
    {
        EnemyContext context;

        private Dictionary<Type, float> probabilities = new Dictionary<Type, float>();
        private float totalProbability = 0;

        public void CalculateProbabilities()
        {
            IEnumerable<EnemyAction> actions = gameObject.GetComponents<MonoBehaviour>().OfType<EnemyAction>();
            totalProbability = 0;

            foreach (var action in actions)
            {
                float probability = action.CalculateProbability(context);
                probabilities[action.GetType()] = probability;
                totalProbability += probability;
            }
        }

        public float GetProbability<T>() where T : EnemyAction
        {
            return probabilities[typeof(T)] / totalProbability;
        }

        public void OnStateChange<T>() where T : EnemyAction
        {
            context.AddAction(typeof(T));
        }
    }

}