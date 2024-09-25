using ProjectZephyr;
using System;
using System.Collections.Generic;
using UnityEditor;

public enum SGLinkPriority
{
    High,
    Medium,
    Low,
}

public class SGLink : IComparable<SGLink>
{
    public SGLinkPriority priority { get; }
    public Func<bool> condition { get; }
    public Type destination { get; }

    public SGLink(SGLinkPriority _priority, Func<bool> _condition, Type _destination)
    {
        priority = _priority;
        condition = _condition;
        destination = _destination;
    }

    public int CompareTo(SGLink other)
    {
        if (other == null)
            return 1;

        return priority.CompareTo(other.priority);
    }

    public bool Check()
    {
        return condition.Invoke();
    }
}

public class SGNode
{
    public State state { get; }
    public List<SGLink> links { get; }

    public SGNode(State _state)
    {
        state = _state;
        links = new List<SGLink>();
    }

    public void AddLink(SGLink link)
    {
        links.Add(link);
        links.Sort();
    }

    public virtual void RemoveLink<T>() where T : State
    {
        links.RemoveAll(link => link.destination is T);
    }
}

[CustomEditor(typeof(StateGraph))]
public class StateGraph: Editor
{
    protected Dictionary<Type, SGNode> stateMap = new Dictionary<Type, SGNode>
    {
        { typeof(EnterState), new SGNode(new EnterState()) },
        { typeof(ExitState), new SGNode(new ExitState()) },
    };

    public SGNode currentNode { get; internal set; }

    public StateGraph()
    {
        LinkStates<EnterState, ExitState>(SGLinkPriority.Low, () => true);
        currentNode = stateMap[typeof(EnterState)];
    }

    public void AddState<T>() where T : State, new()
    {
        AddState(typeof(T), new SGNode(new T()));
    }

    public void AddState<T>(T state) where T : State
    {
        AddState(typeof(T), new SGNode(state));
    }

    public void AddState(Type type, SGNode node)
    {
        stateMap.Add(type, node);
    }

    public void LinkStates<S, D>(SGLinkPriority priority, Func<bool> condition)
       where S : State
       where D : State
    {
        if (stateMap.TryGetValue(typeof(S), out SGNode sourceNode) &&
            stateMap.TryGetValue(typeof(D), out SGNode destinationNode))
        {
            SGLink link = new SGLink(priority, condition, destinationNode.state.GetType());

            sourceNode.AddLink(link);
        }
        else
        {
            throw new ArgumentException("Source or destination state not found in the state map.");
        }
    }

    public void LinkStates<D>(SGLinkPriority priority, Func<bool> condition)
        where D : State
    {
        if (stateMap.TryGetValue(typeof(EnterState), out SGNode sourceNode) &&
            stateMap.TryGetValue(typeof(D), out SGNode destinationNode))
        {
            SGLink link = new SGLink(priority, condition, destinationNode.state.GetType());

            sourceNode.AddLink(link);
        }
        else
        {
            throw new ArgumentException("Destination state not found in the state map.");
        }
    }

    public List<SGLink> GetLinks<T>() where T : State
    {
        if (stateMap.TryGetValue(typeof(T), out SGNode node))
        {
            return node.links;
        }
        else
        {
            throw new ArgumentException("State not found in the state map.");
        }
    }

    public State GetState<T>() where T : State
    {
        if (stateMap.TryGetValue(typeof(T), out SGNode node))
        {
            return node.state;
        }
        else
        {
            throw new ArgumentException("State not found in the state map.");
        }
    }

    public void RemoveState<T>() where T : State
    {
        Type stateType = typeof(T);

        if (stateMap.TryGetValue(stateType, out SGNode nodeToRemove))
        {
            foreach (var node in stateMap.Values)
            {
                node.links.RemoveAll(link => link.destination.GetType() == stateType);
            }

            stateMap.Remove(stateType);
        }
        else
        {
            throw new ArgumentException("State not found in the state map.");
        }
    }

    public void SetState<T>() where T : State
    {
        SetState(typeof(T));
    }

    public void SetState(Type type)
    {
        currentNode = stateMap[type];
    }
}
