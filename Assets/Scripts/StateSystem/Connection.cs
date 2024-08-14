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

    public class Connection : IComparable<Connection>
    { 
        public string stateName { get; }
        private Func<bool> check;
        private Priority priority;

        public Connection(Func<bool> check, string stateName, Priority priority = Priority.Medium)
        {
            this.stateName = stateName;
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