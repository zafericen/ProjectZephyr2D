using System;
using UnityEngine;

namespace ProjectZephyr
{

    public enum StateStatus
    {
        Run,
        Success,
        Failure,
    }

    public class MachineContext
    {
        public Type lastState;
        public GameObject owner;
    }

    public class State
    {
        public StateStatus status { get; internal set; }

        public virtual void OnEnter(MachineContext context)
        {
            status = StateStatus.Run;
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnExit(MachineContext context)
        {
            context.lastState = GetType();
        }
    }

    public class EnterState : State
    {
    }

    public class ExitState : State
    {
    }

}