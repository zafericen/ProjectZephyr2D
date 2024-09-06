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
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerWalkState))), typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy && 
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerDodgeState))), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() =>
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerJumpState))), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerAttackState))), typeof(PlayerAttackState)));
        }
    }

    public partial class PlayerWalkState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() =>
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerDodgeState))), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => 
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerJumpState))), typeof(PlayerJumpState)));
            connections.Add(new Connection(() =>
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerAttackState))), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerDodgeState
    {

        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerWalkState))), typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerDodgeState))), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerJumpState))), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerAttackState))), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerWalkState))), typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerDodgeState))), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerJumpState))), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerAttackState))), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerAttackState { 
        public override void InitialConnections()
        {
            var inputHandler = InputHandler.instance;

            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerWalkState))), typeof(PlayerWalkState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerDodgeState))), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerJumpState))), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy &&
            ValidateInputAndUpdateContext(inputHandler.PlayerStateTypeToInputContext(typeof(PlayerAttackState))), typeof(PlayerAttackState)));

        }
    }
}