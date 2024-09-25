using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public class PlayerStateGraph: StateGraph
    {
        public PlayerStateGraph()
        {
            AddState<PlayerIdleState>();
            AddState<PlayerDodgeState>();
            AddState<PlayerJumpState>();
            AddState<PlayerWalkState>();
            AddState<PlayerAttackState>();
            AddState<PlayerAbilityState>();
            AddState<PlayerNormalAttackState>();
            AddState<PlayerSpecialAttackState>();
            AddState<PlayerWeaponArtState>();

            LinkStates<PlayerIdleState>(SGLinkPriority.Low, () => true);
            LinkStates<PlayerIdleState,PlayerDodgeState>(SGLinkPriority.Medium, () => true);
        }
    }

}