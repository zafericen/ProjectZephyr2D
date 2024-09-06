using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ProjectZephyr
{

    public abstract class AttackStatesBase : PlayerStateBase
    {
        protected PlayerCombat combat;
        protected AttackInputType stateInputType;

        protected AttackStatesBase(GameObject o) : base(o)
        {
            combat = o.GetComponent<PlayerCombat>();
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!combat.weapon.IsAttacking())
            {
                busy = false;
            }
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        protected abstract void SetStateInput();
    }

}