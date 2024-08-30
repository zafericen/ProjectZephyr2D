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
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge,InputActionPhase.Performed), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Jump, InputActionPhase.Performed), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack, InputActionPhase.Performed), typeof(PlayerAttackState)));
        }
    }

    public partial class PlayerRunState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Dodge, InputActionPhase.Performed), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Jump, InputActionPhase.Performed), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Attack, InputActionPhase.Performed), typeof(PlayerAttackState)));

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
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge, InputActionPhase.Performed), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Jump, InputActionPhase.Performed), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack, InputActionPhase.Performed), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Walk, InputActionPhase.Performed), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge, InputActionPhase.Performed), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Jump, InputActionPhase.Performed), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack, InputActionPhase.Performed), typeof(PlayerAttackState)));

        }
    }
}