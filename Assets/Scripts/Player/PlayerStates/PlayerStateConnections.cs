using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public partial class PlayerIdleState
    {

        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy && 
            (context.inputContext = inputHandler.GetInput(InputType.Walk,InputActionPhase.Performed)).type != InputType.None, typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Dodge, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => (context.inputContext = inputHandler.GetInput(InputType.Jump, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Attack, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerAttackState)));
        }
    }

    public partial class PlayerWalkState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => (context.inputContext = inputHandler.GetInput(InputType.Dodge, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => (context.inputContext = inputHandler.GetInput(InputType.Jump, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerJumpState)));
            connections.Add(new Connection(() => (context.inputContext = inputHandler.GetInput(InputType.Attack, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerDodgeState
    {

        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy &&
            (context.inputContext = inputHandler.GetInput(InputType.Walk, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Dodge, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Jump, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Attack, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Walk, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Dodge, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Jump, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Attack, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerAttackState { 
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Walk, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Dodge, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Jump, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && (context.inputContext = inputHandler.GetInput(InputType.Attack, InputActionPhase.Performed)).type != InputType.None, typeof(PlayerAttackState)));

        }
    }
}