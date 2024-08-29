using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerIdleState
    {

        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy &&
            inputHandler.CheckInput(InputType.Walk), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Jump), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack), typeof(PlayerAttackState)));
        }
    }

    public partial class PlayerRunState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Dodge), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Jump), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => inputHandler.CheckInput(InputType.Attack), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerDodgeState
    {

        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy &&
            inputHandler.CheckInput(InputType.Walk), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Jump), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Walk), typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Dodge), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Jump), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && inputHandler.CheckInput(InputType.Attack), typeof(PlayerAttackState)));

        }
    }
}