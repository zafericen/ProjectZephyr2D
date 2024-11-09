using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace CBRN
{

    [Serializable]
    public class Context
    {
        public State current;
    }

    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private Context context;
        private List<State> states;
    
        void Start()
        {
            states = new List<State>(GetComponents<State>());
            states.Sort();
            if (context.current == null)
            {
                if (states.Count == 0)
                {
                    context.current = null;
                }
                else
                {
                    context.current = states[states.Count - 1];
                }
            }
            for (int i = 0; i < states.Count; i++)
            {
                states[i].enabled = false;
            }

            context.current.enabled = true;
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
