using UnityEngine;

namespace ProjectZephyr
{

    public class State
    {
        protected bool busy;
        protected StateContext context;
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
            this.context = context;
        }

        public StateContext GiveContext()
        {
            StateContext context = new StateContext {typeOfState =  this.GetType()};
            return context;
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