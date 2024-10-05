using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectZephyr
{
    public partial class PlayerAttackState : PlayerStateBase
    {
        private StateMachine attacksStateMachine;
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

            Type type = typeof(ExitState);

            switch (recieveContext.inputContext.attackType)
            {
                case AttackInputType.Normal: type = typeof(PlayerNormalAttackState); break;
                case AttackInputType.Special: type = typeof(PlayerSpecialAttackState); break;
                case AttackInputType.WeaponArt: type = typeof(PlayerWeaponArtState); break;
                case AttackInputType.Ability: type = typeof(PlayerAbilityState); break;
            }

            attacksStateMachine.ChangeState(type);
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
