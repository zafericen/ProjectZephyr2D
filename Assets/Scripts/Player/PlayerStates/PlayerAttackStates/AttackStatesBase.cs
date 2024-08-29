using System.Timers;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class AttackStatesBase : PlayerStateBase
    {
        protected PlayerCombat combat;

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
    }

}