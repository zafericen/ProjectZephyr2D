using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ProjectZephyr
{
    public class BossAttackState : BossStateBase
    {
        protected BossCombat combat;

        public override void OnEnter(MachineContext context)
        {
            base.OnEnter(context);
            combat = o.GetComponent<BossCombat>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!combat.IsAttacking())
            {
                status = StateStatus.Success;
            }
        }

        
    }
}
