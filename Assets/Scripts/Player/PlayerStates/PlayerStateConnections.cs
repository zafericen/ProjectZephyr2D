using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerIdleState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.C), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerRunState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => Input.GetKeyDown(KeyCode.Space), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.C), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.N), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerDodgeState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAttackState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy, typeof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            typeof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), typeof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), typeof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAttackState)));

        }
    }

    

    

}