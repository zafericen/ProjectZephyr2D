using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace ProjectZephyr
{

    [Serializable]
    public class Context
    {
        public State current;
    }

    public class StateMachine : MonoBehaviour
    {
        public Context context;
        public List<State> states;

        void Start()
        {
            states = new List<State>(GetComponents<State>());
            states.Sort();
            context.current = states[0];
            for (int i = 1; i < states.Count; i++)
            {
                states[i].enabled = false;
            }
        }

        void Update()
        {
            foreach (var state in states)
            {
                if (state != context.current && state.Check(context))
                {
                    if (context.current.status == Status.WORKING)
                    {
                        context.current.status = Status.FAILURE;
                    }
                    context.current.enabled = false;
                    state.enabled = true;
                    context.current = state;
                    break;
                }
            }
        }
    }
}