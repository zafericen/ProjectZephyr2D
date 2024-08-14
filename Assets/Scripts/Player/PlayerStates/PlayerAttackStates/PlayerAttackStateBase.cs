using System.Timers;
using UnityEngine;

namespace ProjectZephyr
{

    public abstract class PlayerAttackStateBase : PlayerStateBase
    {
        protected PlayerCombat combat;

        protected PlayerAttackStateBase(GameObject o) : base(o)
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