using UnityEngine;
using System;

namespace ProjectZephyr
{

    public enum Priority
    {
        HIGH,
        MEDIUM,
        LOW,
    };

    public enum Status
    {
        SUCCESS,
        FAILURE,
        WORKING,
    }

    public class State : MonoBehaviour, IComparable<State>
    {
        protected Animator Animator;
        [SerializeField]
        protected Priority priority;

        public Status status;

        public virtual bool Check(Context context)
        {
            return false;
        }

        public int CompareTo(State other)
        {
            if (other == null) return 1;
            return priority.CompareTo(other.priority);
        }
    }

}