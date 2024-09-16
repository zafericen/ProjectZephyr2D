using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public abstract class AttackStatesBase : PlayerStateBase
    {
        protected PlayerCombat combat;
        protected AttackInputType stateInputType;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            combat = owner.GetComponent<PlayerCombat>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!combat.weapon.IsAttacking())
            {
                status = StateStatus.Success;
            }
        }

        public override void OnExit(MachineContext context)
        {
            base.OnExit(context);
        }

        protected abstract void SetStateInput();
    }

}