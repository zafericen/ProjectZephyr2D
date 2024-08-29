using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectZephyr
{
    public partial class PlayerNormalAttackState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState),Priority.Low));
        }
    }

    public partial class PlayerSpecialAttackState
    {

        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState), Priority.Low));

        }
    }

    public partial class PlayerWeaponArtState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState), Priority.Low));

        }
    }

    public partial class PlayerAbilityState
    {
        public override void InitialConnections()
        {
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse0), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Mouse1), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.Q), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => !busy && Input.GetKey(KeyCode.N), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState), Priority.Low));
        }
    }
}
