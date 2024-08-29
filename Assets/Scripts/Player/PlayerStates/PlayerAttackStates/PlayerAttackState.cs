using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectZephyr
{
    public class PlayerAttackState : PlayerStateBase
    {
        private StateMachine attacksStateMachine;
        //TODO: Add mapping from movement to attacks
        public PlayerAttackState(GameObject o) : base(o)
        {
            attacksStateMachine = new StateMachine();

            attacksStateMachine.AddState(typeof(PlayerNormalAttackState), new PlayerNormalAttackState(o));
            attacksStateMachine.AddState(typeof(PlayerSpecialAttackState), new PlayerSpecialAttackState(o));
            attacksStateMachine.AddState(typeof(PlayerWeaponArtState), new PlayerWeaponArtState(o));
            attacksStateMachine.AddState(typeof(PlayerAbilityState), new PlayerAbilityState(o));
        }

        public override void OnEnter()
        {
            base.OnEnter();
            attacksStateMachine.ChangeState(context.typeOfState);
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            attacksStateMachine.Run();
            if (attacksStateMachine.IsExit())
            {
                busy = false;
            }

        }

    }
}
