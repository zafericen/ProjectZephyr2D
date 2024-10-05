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
        public BossAttackState(GameObject o) : base(o)
        {
            combat = o.GetComponent<BossCombat>();
        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            if (!combat.IsAttacking())
            {
                busy = false;
            }
        }

        
    }
}
