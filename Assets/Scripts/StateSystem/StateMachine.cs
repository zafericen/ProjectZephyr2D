using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ProjectZephyr
{

    public class StateMachine : MonoBehaviour
    {
        [SerializeField]
        private StateGraph graph;

        private MachineContext context;

        void Start()
        {
            if (graph == null)
            {
                graph = new StateGraph();
            }

            context.owner = gameObject;
        }

        void Update()
        {
            graph.currentNode.state.OnUpdate();

            foreach (var link in graph.currentNode.links)
            {
                if (link.Check() && graph.currentNode.state.status == StateStatus.Success)
                {
                    ChangeState(link.destination);
                }
            }
        }

        public void ChangeState<T>() where T : State
        {
            ChangeState(typeof(T));
        }

        public void ChangeState(Type stateType)
        {
            graph.currentNode.state.OnExit(context);
            graph.SetState(stateType);
            graph.currentNode.state.OnEnter(context);
        }

    }

}
