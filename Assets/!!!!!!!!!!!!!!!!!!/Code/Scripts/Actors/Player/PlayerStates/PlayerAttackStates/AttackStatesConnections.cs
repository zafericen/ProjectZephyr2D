using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{
    public partial class PlayerNormalAttackState
    {
        public override void InitialConnections()
        {

            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Normal }), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Special }), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.WeaponArt }), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Ability }), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState),Priority.Low));
        }
    }

    public partial class PlayerSpecialAttackState
    {

        public override void InitialConnections()
        {

            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Normal }), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Special }), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.WeaponArt }), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Ability }), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState), Priority.Low));

        }
    }

    public partial class PlayerWeaponArtState
    {
        public override void InitialConnections()
        {

            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Normal }), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Special }), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.WeaponArt }), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Ability }), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState), Priority.Low));

        }
    }

    public partial class PlayerAbilityState
    {
        public override void InitialConnections()
        {

            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Normal }), typeof(PlayerNormalAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Special }), typeof(PlayerSpecialAttackState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.WeaponArt }), typeof(PlayerWeaponArtState)));
            connections.Add(new Connection(() => (!busy || isPerfectAttack) && ValidateInputAndUpdateContext(new InputContext { type = InputType.Attack, holdType = InputActionPhase.Performed, attackType = AttackInputType.Ability }), typeof(PlayerAbilityState)));
            connections.Add(new Connection(() => !busy, typeof(ExitState), Priority.Low));
        }
    }
}
