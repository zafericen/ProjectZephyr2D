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
            inputHandler.CheckInput(InputType.Walk,InputActionPhase.Performed), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge,InputActionPhase.Started), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Jump, InputActionPhase.Started), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack, InputActionPhase.Started), typeof(PlayerAttackState)));
        }
    }

    public partial class PlayerRunState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Dodge, InputActionPhase.Started), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Jump, InputActionPhase.Started), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Attack, InputActionPhase.Started), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerDodgeState
    {

        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy &&
            inputHandler.CheckInput(InputType.Walk, InputActionPhase.Performed), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge, InputActionPhase.Started), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Jump, InputActionPhase.Started), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack, InputActionPhase.Started), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Walk, InputActionPhase.Started), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge, InputActionPhase.Started), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Jump, InputActionPhase.Started), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack, InputActionPhase.Started), typeof(PlayerAttackState)));

        }
    }
}