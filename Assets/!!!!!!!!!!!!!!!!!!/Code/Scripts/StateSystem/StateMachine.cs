using System;
using System.Collections.Generic;

namespace ProjectZephyr
{

    public class StateMachine
    {
        private Dictionary<Type, State> states = new Dictionary<Type, State>()
        {
            {typeof(ExitState), new ExitState()},
        };

        public State current;

        public StateMachine(Type starterStateName)
        { 
            current = states[starterStateName];
            current.OnEnter();
        }

        public StateMachine()
        {
            current = states[typeof(ExitState)];
        }

        public void ChangeState(Type type)
        {
            current.OnExit();
            StateContext context = current.GiveContext();
            current = states[type];
            current.TakeContext(context);
            current.OnEnter();
        }

        public virtual void Run()
        {
            current.OnUpdate();

            foreach (var connection in current.connections)
            {
                if (connection.Check() && DoesStateExists(connection.stateType))
                {
                    ChangeState(connection.stateType);
                    break;
                }
            }
        }

        private State GetState(Type type)
        {
            return states[type];
        }

        protected bool DoesStateExists(Type type)
        {
            return states.ContainsKey(type);
        }

        public void AddState(Type type, State state)
        {
            states.Add(type, state);
        }

        public void RemoveState(Type type)
        {
            states.Remove(type);
        }

        public void AddConnection(Type where, Connection connection)
        {
            states[where].AddConnection(connection);
        }

        public bool IsExit()
        {
            return current is ExitState;
        }
    }
}