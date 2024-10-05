using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public class State
    {
        protected bool busy;
        protected StateContext recieveContext;
        protected StateContext sendContext;

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
            busy = false;
        }

        public virtual bool IsBusy()
        {
            return busy;
        }

        public void AddConnection(Connection connection)
        {
            connections.Add(connection);
        }

        public void TakeContext(StateContext context)
        {
            this.recieveContext = context;
        }

        public StateContext GiveContext()
        {
            return sendContext;
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