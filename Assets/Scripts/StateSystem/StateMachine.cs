using System.Collections.Generic;

namespace ProjectZephyr
{

    public class StateMachine
    {
        private Dictionary<string, State> states = new Dictionary<string, State>()
        {
            {nameof(ExitState), new ExitState()},
        };

        public State current;

        public StateMachine(string starterStateName)
        { 
            current = states[starterStateName];
            current.OnEnter();
        }

        public StateMachine()
        {
            current = states[nameof(ExitState)];
        }

        public void ChangeState(string name)
        {
            current.OnExit();
            current = states[name];
            current.OnEnter();
        }

        public void Run()
        {
            current.OnUpdate();

            foreach (var connection in current.connections)
            {
                if (connection.Check())
                {
                    ChangeState(connection.stateName);
                    break;
                }
            }
        }

        public void AddState(string name, State state)
        {
            states.Add(name, state);
        }

        public void RemoveState(string name)
        {
            states.Remove(name);
        }

        public void AddConnection(string where, Connection connection)
        {
            states[where].AddConnection(connection);
        }

        public bool IsExit()
        {
            return current is ExitState;
        }
    }


}