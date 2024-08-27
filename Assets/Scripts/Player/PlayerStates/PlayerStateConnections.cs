using UnityEngine;

namespace ProjectZephyr
{

    public partial class PlayerIdleState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerRunState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerDodgeState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerJumpState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerNormalAttackState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerSpecialAttackState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerWeaponArtState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));

        }
    }

    public partial class PlayerAbilityState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), nameof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), nameof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), nameof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), nameof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy &&
            (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)),
            nameof(PlayerRunState)));
            connections.Add(new Connection(() => !busy, nameof(PlayerIdleState), Priority.XLow));
            connections.Add(new Connection(() => !busy && Input.GetKeyDown(KeyCode.Space), nameof(PlayerDodgeState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.C), nameof(PlayerJumpState)));
        }
    }

}