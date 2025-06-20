using System;

namespace ProjectZephyr
{

    public enum Priority
    {
        XLow,
        Low,
        Medium,
        High,
        XHigh,
    }

    //TODO: get rid of isPerfectAttack
    public struct StateContext
    {
        public Type typeOfState;
        public InputContext inputContext;
        public bool isPerfectAttack;
    }

    public class Connection : IComparable<Connection>
    { 
        public Type stateType { get; }
        private Func<bool> check;
        private Priority priority;

        public Connection(Func<bool> check, Type stateType ,Priority priority = Priority.Medium)
        {
            this.stateType = stateType;
            this.check = check;
            this.priority = priority;
        }

        public bool Check()
        {
            return check();
        }

        public int CompareTo(Connection other)
        {
            return -priority.CompareTo(other.priority);
        }
    }

}