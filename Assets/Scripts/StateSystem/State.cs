using UnityEngine;

namespace ProjectZephyr
{

    public class State
    {
        protected bool busy;
        public PriorityList<Connection> connections { get; } = new PriorityList<Connection>();

        public virtual void OnEnter()
        {
            busy = true;
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnExit()
        {
        }

        public bool IsBusy()
        {
            return busy;
        }

        public void AddConnection(Connection connection)
        {
            connections.Add(connection);
        }

        public virtual void InitialConnections()
        {
        }
    }

    public class MonoState : State
    {
        public MonoState(GameObject o)
        {
            InitialConnections();
        }
    }

    public class ExitState : State
    {
    }

}